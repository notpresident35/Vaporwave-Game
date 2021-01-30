using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;
    public float Damage;

    Rigidbody2D rb;

    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Start () {
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.GetComponent <HealthBarScript> ()) {
            collision.GetComponent<HealthBarScript> ().hurtMe (Damage);
        }
        Destroy (gameObject);
    }
}
