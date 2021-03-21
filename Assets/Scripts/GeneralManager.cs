using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public List<GameObject> rooms;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Instantiate(newRoom, position + distance, Quaternion.identity);
    }
}
