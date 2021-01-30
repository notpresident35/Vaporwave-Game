using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincible : MonoBehaviour
{
    public SpriteRenderer Elmo;
    public CircleCollider2D ElmoHitBox;
    public bool invincible;
    public float interval;
    public float invincibleTime;
    public HealthBarScript health;

    private float timer;
    private bool visible;
    private Coroutine blink;

    public void TakeDamage () {
        if (blink != null) {
            StopCoroutine (blink);
        }
        blink = StartCoroutine ("Blink");
        invincible = true;
        ElmoHitBox.enabled = false;
        timer = interval;
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
        invincible = false;
        Elmo.color = new Color (Elmo.color.r, Elmo.color.g, Elmo.color.b, 1);
    }
}
