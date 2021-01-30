using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

    Vector2 input;
    Rigidbody2D rb;
    Shooter shooter;

    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        shooter = GetComponent<Shooter> ();
    }

    private void Update () {

        // Movement
        input.x = Input.GetAxisRaw ("Horizontal");
        input.y = Input.GetAxisRaw ("Vertical");

        rb.velocity = input.normalized * Speed;
        if (input.magnitude > Mathf.Epsilon) {
            transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (input.y, input.x) * Mathf.Rad2Deg);
        }

        // Shooting
        if (Input.GetKey (KeyCode.Space)) {
            shooter.TryShoot ();
        }
    }
}
