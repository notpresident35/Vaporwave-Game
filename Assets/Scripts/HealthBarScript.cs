using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour {

    public bool useHearts;

    float health;
    int totalHearts;
    GameObject [] hearts;
    GenericKillableEntity entity;

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
            totalHearts = transform.childCount;
            hearts = new GameObject [totalHearts];
            for (int i = 0; i < totalHearts; i++) {
                hearts [i] = transform.GetChild (i).gameObject;
            }
            health = totalHearts;
        } else {
            // TODO: Slider health bar (or no health bar)
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && health > 0) {//Hearts disappear here. Replace with a link to player later?
            hurtMe();
        }
        else if (Input.GetKeyDown(KeyCode.S) && health < totalHearts) {//Hearts reappear here. Replace with a link to player later?
            healMe();
        }
    }

    public void hurtMe() {
        if (useHearts) {
            health--;
            hearts [Mathf.RoundToInt (health)].SetActive (false);

            if (health <= 0) {
                entity.Die ();
            }
        }
    }

    public void healMe() {
        if (useHearts) {
            hearts [Mathf.RoundToInt (health)].SetActive (true);
            health++;
        }
    }
}
