using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public enum Type { Shooter, Chaser };

    public Type enemyType;
    float timer = 0, tMax = 2f;
    float shootInterval = 3f;
    float shootTime = 0;
    bool reloading = false;
    public float health;
    float currentHealth;
    public Image healthBar;
    public float speed;
    public int chaserDamage;
    public Sprite[] shooter_states;
    public Sprite[] chaser_states;
    Sprite[] states;
    int cState = 0;
    SpriteRenderer spriteR;
    public GameObject explosion;
    Transform Player;

    public Transform cannon;
    public GameObject cannonBallPrefab;

    public float cannonBallSpeed;
    GameInfo game;
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        if(enemyType == Type.Shooter)
        {
            states = shooter_states;
        }
        else
        {
            states = chaser_states;
            speed = 1.2f;

        }
        spriteR.sprite = states[cState];
        currentHealth = health;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            timer += Time.deltaTime;
            if(timer >= tMax)
            {
                GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(effect, 0.4f);
                Destroy(gameObject);
            }
        }
        else
        {
            if (enemyType == Type.Shooter)
            {
                shooterUpdate();
            }
            else
            {
                chaserUpdate();
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            cState++;
            spriteR.sprite = states[cState];
            if(currentHealth <= 0)
            {
                game.addPoints();
            }
            healthBar.fillAmount = currentHealth / health;
        }
        
    }
    void shooterUpdate()
    {
        if (reloading)
        {
            shootTime += Time.deltaTime;
            if (shootTime >= shootInterval)
            {
                reloading = false;
                shootTime = 0f;
            }
        }
        transform.up = (Player.position - transform.position) * -1;
        if(Vector2.Distance(transform.position, Player.position) > 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
        else
        {
            if(!reloading)
            {
                GameObject cBall = Instantiate(cannonBallPrefab, cannon.position, cannon.rotation);
                Rigidbody2D rb = cBall.GetComponent<Rigidbody2D>();
                rb.AddForce(cannon.right * cannonBallSpeed, ForceMode2D.Impulse);
                reloading = true;
            }
        }
    }
    void chaserUpdate()
    {
        transform.up = (Player.position - transform.position) * -1;
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }
    public void setType(int t)
    {
        if(t == 0)
        {
            enemyType = Type.Shooter;
            states = shooter_states;
        }
        else
        {
            enemyType = Type.Chaser;
            states = chaser_states;
        }
    }
    public void setPlayerT(Transform t)
    {
        Player = t;
    }
    public void setGame(GameInfo g)
    {
        game = g;
    }
    void chaserCollision()
    {
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyType == Type.Chaser)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().takeDamage(chaserDamage);
                chaserCollision();
            }
        }
    }
}
