using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomogachiMovement : MonoBehaviour
{
    public float speed;
    public float upperBound;
    public float lowerBound;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Random.Range(lowerBound, upperBound),Random.Range(lowerBound, upperBound));
    }
}
