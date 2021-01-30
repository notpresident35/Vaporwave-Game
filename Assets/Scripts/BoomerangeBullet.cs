using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangeBullet : MonoBehaviour
{
    public float Speed;
    public float width;
    public float height;
    public float lifeTime;

    float spawnTime;
    Vector3 startPos;
    Rigidbody2D rb;

    private void Awake()
    {
        spawnTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        float x = Mathf.Cos(Time.time * Speed * 1.1f) * width;
        float y = Mathf.Sin(Time.time * Speed) * height;
        transform.position = new Vector3(startPos.x + x, startPos.y + y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Health and damage
        Destroy(gameObject);
    }
}
