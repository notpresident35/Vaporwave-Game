using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurbyBehavior : MonoBehaviour {

    public float LaserSpinSpeed = 25;
    public Laser LeftLaser;
    public Laser RightLaser;

    Vector2 input;
    Rigidbody2D rb;
    //Furby fb;   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // fb = GetComponent<Furby>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.right;

        LeftLaser.SetTargetPosition (new Vector3 (-2, 1, 0));
        RightLaser.SetTargetPosition (new Vector3 (5, 2, 0));
    }
}
