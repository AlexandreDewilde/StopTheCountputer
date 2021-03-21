using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public int maxX = 5;
    public int maxY = 5;

    public GameObject CPURoom;
    public List<GameObject> rooms;
    private Vector3 coordsCPURoom;

    private List<Vector3> roomsCoords = new List<Vector3>();
    // Start is called before the first frame update
    void Awake()
    {
        coordsCPURoom = new Vector3(12.5f * Random.Range(3,6), 12.5f * Random.Range(3, 6), 0);
        roomsCoords.Add(new Vector3(0,0,0));
    }

    void Start()
    {
        //Instantiate(CPURoom, coordsCPURoom, Quaternion.Identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRoom(Vector3 position, Vector3 direction)
    {
        GameObject newRoom = rooms[Random.Range(0, rooms.Count)];
        Vector3 distance = new Vector3(12.5f,12.5f,0f);
        distance.x = distance.x * direction.x;
        distance.y = distance.y * direction.y;
        Vector3 roomPosition = distance + position;
        if (!CheckIfCoordsExist(roomPosition))
        {
            Instantiate(newRoom, roomPosition, Quaternion.identity);
            roomsCoords.Add(roomPosition);
        }
    }

    bool CheckIfCoordsExist(Vector3 coords)
    {
        Debug.Log(coords.x);
        foreach (Vector3 roomCoord in roomsCoords)
        {
            Debug.Log(roomCoord.x);
            Debug.Log(roomCoord.y);
            if (roomCoord.x == coords.x && roomCoord.y == coords.y) return true;

        }
        return false;
    }
}
