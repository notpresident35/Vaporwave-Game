using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBehavior : MonoBehaviour, GenericKillableEntity
{
    GameObject Target;
    public float damagePauseTime;
    public float speed;
    private float step;
    private bool isActive = true;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.GetComponent<HealthBarScript> ()) {
            collision.GetComponent<HealthBarScript> ().hurtMe (1);
            isActive = false;
            StartCoroutine (reEnable ());
        }
    }

    IEnumerator reEnable () {
        yield return new WaitForSeconds (damagePauseTime);
        isActive = true;
    }

    // Update is called once per frame
    void Update() {

        if (!isActive) { return; }

        float dist = Vector2.Distance(transform.position, Target.GetComponent<Transform>().position);
        if (dist > .001f) {
            step = speed / dist * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Target.GetComponent<Transform>().position, step);
        }
    }

    public void Die () {
        DoorController.EnemyDied ();
        Destroy (gameObject);
    }
}
