using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullet : MonoBehaviour
{
    public float Speed;
    public int bounces;//How many times the bullet can bounce
    private int numBounces;//How many times the bullet has bounced
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        numBounces = 0;
    }

    private void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (numBounces < bounces) {
            // TODO: Health and damage
            numBounces++;
        }
        else {
            // TODO: Health and damage
            Destroy(gameObject);
        }
    }
}
