using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangeBullet : MonoBehaviour
{
    public float Speed;
    public float width;
    public float height;
    private float timer;
    Vector3 sartPos;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
        sartPos = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime * Speed;
        float x = Mathf.Cos(timer)* width;
        float y = Mathf.Sin(timer)* height;
        transform.position = new Vector3(sartPos.x + x, sartPos.y + y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Health and damage
        Destroy(gameObject);
    }
}
