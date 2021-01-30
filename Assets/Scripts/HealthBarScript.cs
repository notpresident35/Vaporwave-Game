using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour {

    public bool useHearts;
    public GameObject [] hearts;
    public float health;

    int totalHearts;
    GenericKillableEntity entity;
    PlayerInvincible inv;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent) {
            entity = transform.parent.GetComponent<GenericKillableEntity> ();
            transform.parent = null;
        } else {
            entity = GetComponent<GenericKillableEntity> ();
        }

        if (useHearts) {
            totalHearts = hearts.Length;
            health = totalHearts;
        } else {
            // TODO: Slider health bar (or no health bar)
        }

        if (GetComponent<PlayerInvincible> ()) {
            inv = GetComponent<PlayerInvincible> ();
        }
    }

    public void hurtMe(float damage) {

        if (health <= 0) { return; }

        if (inv && !inv.invincible) {
            inv.TakeDamage ();
        }

        if (useHearts) {
            health--;
            hearts [Mathf.RoundToInt (health)].SetActive (false);
        } else {
            health -= damage;
        }

        if (health <= 0) {
            entity.Die ();
        }
    }

    public void healMe(float healing) {
        if (useHearts) {
            hearts [Mathf.RoundToInt (health)].SetActive (true);
            health++;
        } else {
            health += healing;
        }
    }
}
