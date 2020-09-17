using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform cannon;
    public Transform sideCannon1, sideCannon2;
    public GameObject cannonBallPrefab;
    Player pl;
    public float cannonBallSpeed;
    void Start()
    {
        pl = GetComponent<Player>();
    }

    void Update()
    {
        if (!pl.dead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                SideFire();
            }
        }
    }
    void Fire()
    {
        GameObject cBall = Instantiate(cannonBallPrefab, cannon.position, cannon.rotation);
        Rigidbody2D rb = cBall.GetComponent<Rigidbody2D>();
        rb.AddForce(cannon.right * cannonBallSpeed, ForceMode2D.Impulse);
    }
    void SideFire()
    {
        GameObject cBall1 = Instantiate(cannonBallPrefab, sideCannon1.position, sideCannon1.rotation);
        Rigidbody2D rb1 = cBall1.GetComponent<Rigidbody2D>();
        rb1.AddForce(sideCannon1.right * cannonBallSpeed, ForceMode2D.Impulse);
        GameObject cBall2 = Instantiate(cannonBallPrefab, sideCannon2.position, sideCannon2.rotation);
        Rigidbody2D rb2 = cBall2.GetComponent<Rigidbody2D>();
        rb2.AddForce(sideCannon2.right * cannonBallSpeed, ForceMode2D.Impulse);
    }
}
