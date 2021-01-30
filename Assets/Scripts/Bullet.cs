using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;

    Rigidbody2D rb;

    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Start () {
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        // TODO: Health and damage
        Destroy (gameObject);
    }
}
