using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TomoAkbar : MonoBehaviour,GenericKillableEntity
{
    public GameObject moreTomo;
    public Animator TomoEggs;
    public int numTomosSpawned;
    public float timeTilDeath;
    public float spawnForce;
    private float timer;
    private TomogachiMovement tm;
    private Rigidbody2D rb;
    void Start()
    {
        tm = GetComponent<TomogachiMovement>();
        rb = GetComponent<Rigidbody2D>();
        timer = timeTilDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomRoomGenerator.MovingRooms || Player.isDead) { return; }

        timer -= Time.deltaTime;
        if (timer <= 0) {
            spawnNewTomos();
        }
    }

    void spawnNewTomos() {
        tm.enabled = false;
        rb.velocity = Vector2.zero;
        TomoEggs.SetTrigger("Start");
    }

    void BlowUp() {
        Rigidbody2D clone;
        for (int i = 0; i < numTomosSpawned; i++) {
            clone = Instantiate(moreTomo, transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f),0), transform.rotation).GetComponent<Rigidbody2D>();
            clone.velocity = transform.TransformDirection(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0) * spawnForce);
            DoorController.EnemySpawned();
        }
        DoorController.EnemyDied();
        Destroy(gameObject);
    }

    public void Die()
    {
        DoorController.EnemyDied();
        Destroy(gameObject);
    }
}
