using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomGenerator : MonoBehaviour {

    public static bool MovingRooms;

    public int RoomsClearedToWin = 15;
    public int RoomsCleared = 0;
    public float gridToWorldSpaceSize;
    public float doorOffset;
    public float playerOffset;

    int currentGridX;
    int currentGridY;

    public struct DungeonRoom {
        public GameObject instance;
        public int gridX;
        public int gridY;

        public DungeonRoom (GameObject instance, int gridX, int gridY) {
            this.instance = instance;
            this.gridX = gridX;
            this.gridY = gridY;
        }
    }

    [System.Serializable]
    public struct DungeonRoomPrefab {
        public GameObject prefab;
        public int enemyCount;
    }

    public PlayerInvincible invincible;
    public Transform Player;
    public DoorController doorController;
    public CameraController camController;
    public DungeonRoomPrefab [] DungeonRoomPrefabs;
    public GameObject EmptyRoomPrefab;
    public GameObject Walkman;
    public GameObject DoorPrefab;
    public GameObject BoundaryPrefab;
    public GameObject SealedBoundaryPrefab;
    public GameObject BackgroundPrefab;
    List<DungeonRoom> rooms = new List<DungeonRoom>();

    private void Awake () {
        Player = GameObject.FindGameObjectWithTag ("Player").transform;
        GenerateEmptyRoom (0, 0, 0, 0);
    }

    public void MoveToRoom (int gridXDelta, int gridYDelta) {

        MovingRooms = true;

        bool isNewRoom = true;
        foreach (DungeonRoom room in rooms) {
            if (room.gridX == currentGridX + gridXDelta && room.gridY == currentGridY + gridYDelta) {
                // There's a room here; don't spawn a new one
                isNewRoom = false;
            }
        }

        doorController.currentRoomPosition = new Vector3 ((currentGridX + gridXDelta) * gridToWorldSpaceSize, (currentGridY + gridYDelta) * gridToWorldSpaceSize);

        if (isNewRoom) {
            RoomsCleared++;
            if (RoomsCleared >= RoomsClearedToWin) {
                GenerateFinalRoom (currentGridX + gridXDelta, currentGridY + gridYDelta, gridXDelta, gridYDelta);
            } else {
                GenerateNewRoom (gridXDelta, gridYDelta);
            }
        }

        // Position player
        Player.position = doorController.currentRoomPosition + new Vector2 (-gridXDelta, -gridYDelta) * playerOffset;

        // Target camera
        camController.TargetNewPosition (doorController.currentRoomPosition);

        currentGridX += gridXDelta;
        currentGridY += gridYDelta;

        StartCoroutine (moveRooms ());
    }

    public void GenerateNewRoom (int gridXDelta, int gridYDelta) {

        int newRoomChoice = Random.Range (0, DungeonRoomPrefabs.Length);

        // Dungeon (IE enemies, objects, traps)
        DungeonRoom newRoom = new DungeonRoom (Instantiate (DungeonRoomPrefabs [newRoomChoice].prefab, doorController.currentRoomPosition, Quaternion.identity, transform), currentGridX + gridXDelta, currentGridY + gridYDelta);
        rooms.Add (newRoom);


        Instantiate (DoorPrefab, new Vector3 (newRoom.gridX * gridToWorldSpaceSize - doorOffset, newRoom.gridY * gridToWorldSpaceSize), Quaternion.Euler (0, 0, 90), newRoom.instance.transform);
        Instantiate (DoorPrefab, new Vector3 (newRoom.gridX * gridToWorldSpaceSize + doorOffset, newRoom.gridY * gridToWorldSpaceSize), Quaternion.Euler (0, 0, -90), newRoom.instance.transform);
        Instantiate (DoorPrefab, new Vector3 (newRoom.gridX * gridToWorldSpaceSize, newRoom.gridY * gridToWorldSpaceSize + doorOffset), Quaternion.identity, newRoom.instance.transform);
        Instantiate (DoorPrefab, new Vector3 (newRoom.gridX * gridToWorldSpaceSize, newRoom.gridY * gridToWorldSpaceSize - doorOffset), Quaternion.Euler (0, 0, 180), newRoom.instance.transform);

        // Boundary
        Instantiate (BoundaryPrefab, new Vector3 (newRoom.gridX * gridToWorldSpaceSize, newRoom.gridY * gridToWorldSpaceSize), Quaternion.identity, newRoom.instance.transform);

        // Background
        Instantiate (BackgroundPrefab, new Vector3 (newRoom.gridX * gridToWorldSpaceSize, newRoom.gridY * gridToWorldSpaceSize), Quaternion.identity, newRoom.instance.transform);

        // Logic setup
        DoorController.EnemiesRemainingInRoom = DungeonRoomPrefabs [newRoomChoice].enemyCount;
        DoorController.RoomIsClear = DungeonRoomPrefabs [newRoomChoice].enemyCount <= 0;
    }

    public void GenerateFinalRoom (int gridXPosition, int gridYPosition, int gridXDelta, int gridYDelta) {

        // Dungeon (IE enemies, objects, traps)
        DungeonRoom newRoom = new DungeonRoom (Walkman, currentGridX + gridXDelta, currentGridY + gridYDelta);
        Walkman.transform.position = new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize);
        rooms.Add (newRoom);

        // Boundary
        Instantiate (SealedBoundaryPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize), Quaternion.identity, newRoom.instance.transform);

        // Background
        Instantiate (BackgroundPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize), Quaternion.identity, newRoom.instance.transform);
    }

    public void GenerateEmptyRoom (int gridXPosition, int gridYPosition, int gridXDelta, int gridYDelta) {

        // Dungeon (IE enemies, objects, traps)
        DungeonRoom newRoom = new DungeonRoom (Instantiate (EmptyRoomPrefab, doorController.currentRoomPosition, Quaternion.identity, transform), currentGridX + gridXDelta, currentGridY + gridYDelta);
        rooms.Add (newRoom);

        Instantiate (DoorPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize + doorOffset, gridYPosition * gridToWorldSpaceSize), Quaternion.Euler (0, 0, -90), newRoom.instance.transform);
        Instantiate (DoorPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize - doorOffset, gridYPosition * gridToWorldSpaceSize), Quaternion.Euler (0, 0, 90), newRoom.instance.transform);
        Instantiate (DoorPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize + doorOffset), Quaternion.identity, newRoom.instance.transform);
        Instantiate (DoorPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize - doorOffset), Quaternion.Euler (0, 0, 180), newRoom.instance.transform);

        // Boundary
        Instantiate (BoundaryPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize), Quaternion.identity, newRoom.instance.transform);

        // Background
        Instantiate (BackgroundPrefab, new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize), Quaternion.identity, newRoom.instance.transform);

        // Logic setup
        DoorController.EnemiesRemainingInRoom = 0;
        DoorController.RoomIsClear = true;
    }

    IEnumerator moveRooms () {
        yield return new WaitForSeconds (1);
        invincible.TakeDamage ();
        yield return new WaitForSeconds (1);
        MovingRooms = false;
    }
}
