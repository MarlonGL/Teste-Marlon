using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject explosion;
    public int damageOnEnemy;
    public int damageOnPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageOnEnemy);
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            collision.gameObject.GetComponent<Player>().takeDamage(damageOnPlayer);
            //Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
