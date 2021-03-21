using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public int maxX = 5;
    public int maxY = 5;

    public GameObject CPURoom;
    
    public GameObject bigDoor;
    public List<GameObject> rooms;
    private Vector3 coordsCPURoom;

    private List<Vector3> roomsCoords = new List<Vector3>();
    // Start is called before the first frame update
    void Awake()
    {
        coordsCPURoom = new Vector3(12.5f * Random.Range(3,6), 12.5f * Random.Range(3, 6), 0);
        roomsCoords.Add(new Vector3(0,0,0));
    }

    public void GenerateRoom(Vector3 position, Vector3 direction)
    {
        GameObject newRoom = rooms[Random.Range(0, rooms.Count)];
        Vector3 distance = new Vector3(25f,25f,0f);
        distance.x = distance.x * direction.x;
        distance.y = distance.y * direction.y;
        Vector3 roomPosition = distance + position;
        if (!CheckIfCoordsExist(roomPosition))
        {
            RoomMethods createdRoom = Instantiate(newRoom, roomPosition, Quaternion.identity).GetComponent<RoomMethods>();
            createdRoom.DestroyDoor(DoorToDeleteFromDirection(direction));
            roomsCoords.Add(roomPosition);
            float x = roomPosition.x / 25f;
            float y = roomPosition.y / 25f;
            Debug.Log(x);
            if (x <= -1)
            {
                Instantiate(bigDoor, roomPosition - new Vector3(12.5f,0,0), Quaternion.Euler(0, 0, 90));
            }
            if (x >= maxX)
            {
                Instantiate(bigDoor, roomPosition + new Vector3(12.5f,0,0), Quaternion.Euler(0, 0, 90));
            }
            if (y <= -1)
            {
                Instantiate(bigDoor, roomPosition - new Vector3(0,12.5f,0), Quaternion.Euler(0, 0, 0));
            }
            if (y >= maxY)
            {
                Instantiate(bigDoor, roomPosition + new Vector3(0,12.5f,0), Quaternion.Euler(0, 0, 0));
            }
        }
    }

    string DoorToDeleteFromDirection(Vector3 direction)
    {
        if (direction.x == 1) return "left";
        if (direction.x == -1) return "right";
        if (direction.y == -1) return "up";
        if (direction.y == 1) return "down";
        return "none";
    }

    bool CheckIfCoordsExist(Vector3 coords)
    {
        foreach (Vector3 roomCoord in roomsCoords)
        {
            if (roomCoord.x == coords.x && roomCoord.y == coords.y) return true;

        }
        return false;
    }
}
