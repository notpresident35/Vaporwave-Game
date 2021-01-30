using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangeBullet : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public float lifeTime;
    public float RotationSpeed;

    float spawnTime;
    Rigidbody2D rb;

    private void Awake() {
        spawnTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        if (Time.time - spawnTime > lifeTime) {
            rb.angularVelocity = 0;
        } else {
            rb.angularVelocity = RotationSpeed;
        }

        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<HealthBarScript> ()) {
            collision.transform.GetComponent<HealthBarScript> ().hurtMe (Damage);
        }
        Destroy (gameObject);
    }
}
