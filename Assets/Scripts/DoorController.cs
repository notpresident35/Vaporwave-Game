using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public static bool RoomIsClear = false;
    public static int EnemiesRemainingInRoom = 1;

    public Vector2 currentRoomPosition;
    public float detectionRange = 3;
    public float enterDoorDistance = 8;
    public Transform [] doors;
    public RandomRoomGenerator roomGenerator;
    private Transform player;

    private void Start () {
        player = GameObject.FindWithTag ("Player").transform;
    }

    private void Update () {

        if (!RoomIsClear || RandomRoomGenerator.MovingRooms || Player.isDead) { return; }

        for (int i = 0; i < doors.Length; i++) {
            doors [i].GetComponent<Animator> ().SetBool ("IsOpen", (player.position - doors [i].position).magnitude < detectionRange);
            doors [i].GetComponent<Collider2D> ().enabled = !((player.position - doors [i].position).magnitude < detectionRange);
        }

        if (player.position.x - currentRoomPosition.x > enterDoorDistance) {
            // Entered right door
            for (int i = 0; i < doors.Length; i++) {
                doors [i].GetComponent<Animator> ().SetBool ("IsOpen", false);
                doors [i].GetComponent<Collider2D> ().enabled = true;
            }
            roomGenerator.MoveToRoom (1, 0);
        } else if (player.position.x - currentRoomPosition.x < -enterDoorDistance) {
            // Entered left door
            for (int i = 0; i < doors.Length; i++) {
                doors [i].GetComponent<Animator> ().SetBool ("IsOpen", false);
                doors [i].GetComponent<Collider2D> ().enabled = true;
            }
            roomGenerator.MoveToRoom (-1, 0);
        }
        
        if (player.position.y - currentRoomPosition.y > enterDoorDistance) {
            // Entered top door
            for (int i = 0; i < doors.Length; i++) {
                doors [i].GetComponent<Animator> ().SetBool ("IsOpen", false);
                doors [i].GetComponent<Collider2D> ().enabled = true;
            }
            roomGenerator.MoveToRoom (0, 1);
        } else if (player.position.y - currentRoomPosition.y < -enterDoorDistance) {
            // Entered bottom door
            for (int i = 0; i < doors.Length; i++) {
                doors [i].GetComponent<Animator> ().SetBool ("IsOpen", false);
                doors [i].GetComponent<Collider2D> ().enabled = true;
            }
            roomGenerator.MoveToRoom (0, -1);
        }
    }

    public static void EnemyDied () {
        if (RoomIsClear) { Debug.LogWarning ("Uhhhhh"); return; }
        EnemiesRemainingInRoom--;
        if (EnemiesRemainingInRoom <= 0) {
            RoomIsClear = true;
        }
    }

    public static void EnemySpawned () {
        EnemiesRemainingInRoom++;
    }
}
