using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurbyBehavior : MonoBehaviour
{
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
    }
}
