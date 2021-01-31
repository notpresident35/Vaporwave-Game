using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float detectionRange = 3;

    Transform player;
    Animator animator;
    Collider2D boxCol;

    private void Awake () {
        player = GameObject.FindWithTag ("Player").transform;
        animator = GetComponent<Animator> ();
        boxCol = GetComponent<Collider2D> ();
    }

    private void Update () {
        if (!DoorController.RoomIsClear || RandomRoomGenerator.MovingRooms) {
            animator.SetBool ("IsOpen", false);
            boxCol.enabled = false;
            return;
        }

        animator.SetBool ("IsOpen", (player.position - transform.position).magnitude < detectionRange);
        boxCol.enabled = !((player.position - transform.position).magnitude < detectionRange);
    }
}
