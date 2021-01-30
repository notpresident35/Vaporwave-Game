using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurbyBehavior : MonoBehaviour, GenericKillableEntity {

    public float LaserSpinSpeed = 25;
    public Laser LeftLaser;
    public Laser RightLaser;
    public float AttackDelay = 5f;
    public float AttackLength = 3f;
    public float LaserRange = 25f;

    Vector2 input;
    Rigidbody2D rb;
    float iterator;
    //Furby fb;   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        iterator = AttackDelay / 2;
        // fb = GetComponent<Furby>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.right;

        iterator += Time.deltaTime;
        if (iterator > AttackDelay) {
            StartCoroutine (Attack ());
            iterator = 0;
        }
    }

    IEnumerator Attack () {

        LeftLaser.Active = true;
        RightLaser.Active = true;

        for (float i = 0; i < AttackLength / 2; i += Time.deltaTime) {
            float angle = Mathf.PerlinNoise (0, Time.time * LaserSpinSpeed) * Mathf.Rad2Deg;
            Vector3 targetPos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle)) * Mathf.Clamp01 (i * i);

            LeftLaser.SetTargetPosition (targetPos * LaserRange + transform.position);
            RightLaser.SetTargetPosition (targetPos * LaserRange + transform.position);

            yield return null;
        }

        for (float i = 0; i < AttackLength / 2; i += Time.deltaTime) {
            float angle = Mathf.PerlinNoise (157, Time.time * LaserSpinSpeed) * Mathf.Rad2Deg;
            Vector3 targetPos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle));

            LeftLaser.SetTargetPosition (targetPos * LaserRange + transform.position);
            RightLaser.SetTargetPosition (targetPos * LaserRange + transform.position);

            yield return null;
        }

        for (float i = 0; i < AttackLength / 2; i += Time.deltaTime) {
            float angle = Mathf.PerlinNoise (0, Time.time * LaserSpinSpeed) * Mathf.Rad2Deg;
            Vector3 targetPos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle)) * (1 - Mathf.Clamp01 (i * i));

            LeftLaser.SetTargetPosition (targetPos * LaserRange + transform.position);
            RightLaser.SetTargetPosition (targetPos * LaserRange + transform.position);

            yield return null;
        }

        LeftLaser.SetTargetPosition (transform.position);
        RightLaser.SetTargetPosition (transform.position);
        LeftLaser.Active = false;
        RightLaser.Active = false;
        iterator = 0;
    }

    public void Die () {
        Destroy (gameObject);
    }
}
