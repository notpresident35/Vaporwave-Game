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
        if (RandomRoomGenerator.MovingRooms || Player.isDead) { return; }

        rb.velocity = Vector3.right;

        iterator += Time.deltaTime;
        if (iterator > AttackDelay) {
            StartCoroutine (Attack ());
            iterator = 0;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.GetComponent<HealthBarScript> ()) {
            collision.GetComponent<HealthBarScript> ().hurtMe (1);
        }
    }

    IEnumerator Attack () {

        LeftLaser.Active = true;
        RightLaser.Active = true;

        for (float i = 0; i < 1; i += Time.deltaTime * AttackLength / 3) {
            Vector3 targetPos = GetNoisyPosition () * Mathf.Clamp01 (i * i);

            LeftLaser.SetTargetPosition (targetPos * LaserRange + transform.position);
            RightLaser.SetTargetPosition (targetPos * LaserRange + transform.position);

            yield return null;
        }

        for (float i = 0; i < 1; i += Time.deltaTime * AttackLength / 2) {
            Vector3 targetPos = GetNoisyPosition ();

            LeftLaser.SetTargetPosition (targetPos * LaserRange + transform.position);
            RightLaser.SetTargetPosition (targetPos * LaserRange + transform.position);

            yield return null;
        }

        for (float i = 0; i < 1; i += Time.deltaTime * AttackLength / 6) {
            Vector3 targetPos = GetNoisyPosition () * (1 - Mathf.Clamp01 (i * i));

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

    Vector3 GetNoisyPosition () {
        float angle = Mathf.PerlinNoise (157, Time.time * LaserSpinSpeed) * Mathf.Rad2Deg;
        return new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle));
    }

    public void Die () {
        DoorController.EnemyDied ();
        Destroy (gameObject);
    }
}
