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
    private bool visible;
    private Coroutine blink;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            StopCoroutine("Blink");
            ElmoHitBox.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (blink != null) {
            StopCoroutine (blink);
        }
        blink = StartCoroutine ("Blink");
        ElmoHitBox.enabled = false;
        timer = invincibleTime;
    }

    IEnumerator Blink()
    {
        for (float i = 0; i < invincibleTime; i += Time.deltaTime) {
            if (timer > interval) {
                timer = 0;
                visible = !visible;
                Elmo.color = new Color (Elmo.color.r, Elmo.color.g, Elmo.color.b, visible ? 1 : 0);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        ElmoHitBox.enabled = true;
        Elmo.color = new Color (Elmo.color.r, Elmo.color.g, Elmo.color.b, 1);
    }
}
