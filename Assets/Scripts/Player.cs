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
        input.x = Input.GetAxis ("Horizontal");
        input.y = Input.GetAxis ("Vertical");

        rb.velocity = input.normalized * Speed;

        // Shooting
        if (Input.GetKey (KeyCode.Space)) {
            shooter.TryShoot ();
        }
    }
}
