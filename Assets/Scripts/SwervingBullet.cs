using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwervingBullet : MonoBehaviour {

    public float Damage;
    public float Speed;
    public float RotationSpeed;
    public float RotationFrequency;

    Rigidbody2D rb;

    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        rb.angularVelocity = RotationSpeed * Mathf.Sin (Time.time * RotationFrequency);
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.transform.GetComponent<HealthBarScript> ()) {
            collision.transform.GetComponent<HealthBarScript> ().hurtMe (Damage);
        }
        Destroy (gameObject);
    }
}
