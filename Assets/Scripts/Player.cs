using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health;
    float currentHealth;
    SpriteRenderer spriteR;
    public Sprite[] states;
    Rigidbody2D rb;
    public float speed, rotationSpeed;
    public Image healthBar;
    public GameInfo game;
    public bool dead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        currentHealth = health;
    }
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position -= transform.up * Time.deltaTime * speed;
            }
        }
    }
    public void takeDamage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth < 40)
            {
                spriteR.sprite = states[2];
            }
            else if (currentHealth < 70)
            {
                spriteR.sprite = states[1];
            }
            //cStates++;
            //spriteR.sprite = states[cStates];
            healthBar.fillAmount = currentHealth / health;
        }else if(currentHealth <= 0)
        {
            dead = true;
            spriteR.sprite = states[3];
            Invoke("openEndPanel", 1.5f);
        }
        
    }
    void openEndPanel()
    {
        game.OpenEndPanel("Game Over");
    }
}
