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
}
