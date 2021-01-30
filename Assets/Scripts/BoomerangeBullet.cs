using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangeBullet : MonoBehaviour
{
    public float Speed;
    public float width;
    public float height;
    public float lifeTime;
    public float RotationSpeed;

    bool dead = false;
    float spawnTime;
    Vector3 startPos;
    Vector2 pos = Vector2.zero;
    Vector2 dir = Vector2.zero;
    Rigidbody2D rb;

    private void Awake()
    {
        spawnTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        if (Time.time - spawnTime > lifeTime) {
            //pos += Speed * dir * Time.deltaTime;
            rb.angularVelocity = 0;
        } else {
            /*dir.x = Mathf.Cos (Time.time * Speed * 1.1f) * width - pos.x;
            dir.y = Mathf.Cos (Time.time * Speed) * height - pos.y;

            pos.x = Mathf.Cos (Time.time * Speed * 1.1f) * width;
            pos.y = Mathf.Sin (Time.time * Speed) * height;*/
            rb.angularVelocity = RotationSpeed;
            //transform.Translate (transform.right * Speed * Time.deltaTime);
        }
        rb.velocity = transform.right * Speed;
        //transform.position = new Vector3(startPos.x + pos.x, startPos.y + pos.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Health and damage
        Destroy(gameObject);
    }
}
