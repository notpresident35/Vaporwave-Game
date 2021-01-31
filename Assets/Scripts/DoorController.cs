using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public static bool RoomIsClear = false;
    public static int EnemiesRemainingInRoom = 1;

    public float detectionRange = 3;
    public float enterDoorDistance = 8;
    public Transform [] doors;

    private Animator [] doorAnims = new Animator[4];
    private Collider2D [] doorCols = new Collider2D [4];
    private Transform player;

    private void Awake () {
        player = GameObject.FindWithTag ("Player").transform;
        for (int i = 0; i < doors.Length; i++) {
            doorAnims [i] = doors [i].GetComponent<Animator> ();
            doorCols [i] = doors [i].GetComponent<Collider2D> ();
        }
    }

    private void Update () {

        if (!RoomIsClear) { return; }

        for (int i = 0; i < doors.Length; i++) {
            doorAnims [i].SetBool ("IsOpen", (player.position - doors [i].position).magnitude < detectionRange);
            doorCols [i].enabled = !((player.position - doors [i].position).magnitude < detectionRange);
        }

        if (player.position.x > enterDoorDistance) {
            // Entered right door
        } else if (player.position.x < -enterDoorDistance) {
            // Entered left door
        }
        
        if (player.position.y > enterDoorDistance) {
            // Entered top door
        } else if (player.position.y < -enterDoorDistance) {
            // Entered bottom door
        }
    }

    public static void EnemyDied () {
        if (RoomIsClear) { Debug.LogWarning ("Uhhhhh"); return; }
        EnemiesRemainingInRoom--;
        if (EnemiesRemainingInRoom <= 0) {
            RoomIsClear = true;
        }
    }
}
