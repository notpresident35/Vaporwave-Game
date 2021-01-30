using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBehavior : MonoBehaviour, GenericKillableEntity
{
    GameObject Target;
    public float speed;
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Target.GetComponent<Transform>().position);
        if (dist > .001f) {
            step = speed / dist * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Target.GetComponent<Transform>().position, step);
        }
    }

    public void Die () {
        Destroy (gameObject);
    }
}
