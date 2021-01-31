using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, GenericKillableEntity {

    public static bool isDead = false;

    public float Speed;
    public float TurnSmoothing;
    public Transform Gun;
    public Transform Elmo;
    public bool trapped;
    public bool spedUp;

    Vector2 input;
    Vector3 mousePos;
    Rigidbody2D rb;
    Shooter shooter;
    Camera cam;
    Vector3 startScale;

    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        shooter = GetComponent<Shooter> ();
        startScale = Elmo.localScale;
        cam = Camera.main;
    }

    private void Update () {

        if (isDead || RandomRoomGenerator.MovingRooms) { rb.velocity = Vector3.zero; return; }

        // Movement
        if (!trapped) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (spedUp && input.magnitude < Mathf.Epsilon)
            {

            }
            else
            {
                rb.velocity = input.normalized * Speed;
            }
            if (input.magnitude > Mathf.Epsilon)
            {
                Elmo.localScale = new Vector3((input.x < 0 ? 1 : -1) * startScale.x, startScale.y, startScale.z);
            }
        }

        // Aiming
        mousePos = Input.mousePosition;
        mousePos.z = -10;
        mousePos = cam.ScreenToWorldPoint (mousePos);
        Gun.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);

        // Shooting
        if (Input.GetKey (KeyCode.Mouse0)) {
            shooter.TryShoot ();
        }
    }

    public void Die () {
        // TODO: Fancy death cutscene!
        isDead = true;
        print ("Player died!");
    }
}
