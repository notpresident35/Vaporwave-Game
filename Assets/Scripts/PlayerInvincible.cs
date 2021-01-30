using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincible : MonoBehaviour
{
    public SpriteRenderer Elmo;
    public CircleCollider2D ElmoHitBox;
    public float interval;
    public float invincibleTime;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            StopCoroutine("Blink");
            ElmoHitBox.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("Blink");
        timer = invincibleTime;
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (Elmo.color.a.ToString())
            {
                case "0":
                    Elmo.color = new Color(Elmo.color.r, Elmo.color.g, Elmo.color.b, 1);
                    yield return new WaitForSeconds(interval);
                    break;
                case "1":
                    Elmo.color = new Color(Elmo.color.r, Elmo.color.g, Elmo.color.b, 0);
                    yield return new WaitForSeconds(interval);
                    break;
            }
        }
    }
}
