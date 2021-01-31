using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomGenerator : MonoBehaviour {

    public int RoomsCleared = 0;
    public float gridToWorldSpaceSize;

    struct DungeonRoom {
        public GameObject instance;
        public int gridX;
        public int gridY;
    }

    public GameObject [] DungeonRoomPrefabs;
    public GameObject FinalRoom;
    List<DungeonRoom> rooms = new List<DungeonRoom>();

    public void GenerateNewRoom (int gridXPosition, int gridYPosition) {

        // Dungeon (IE enemies, objects, traps)
        DungeonRoom newRoom = new DungeonRoom ();
        newRoom.gridX = gridXPosition;
        newRoom.gridY = gridYPosition;
        newRoom.instance = Instantiate (DungeonRoomPrefabs [Random.Range (0, DungeonRoomPrefabs.Length)], new Vector3 (gridXPosition * gridToWorldSpaceSize, gridYPosition * gridToWorldSpaceSize), Quaternion.identity, transform);
        rooms.Add (new DungeonRoom ());

        // Doors
        foreach (DungeonRoom room in rooms) {
            if (room.gridX == gridXPosition && room.gridY == gridYPosition) {

            }
        }


        // Background

    }
}
