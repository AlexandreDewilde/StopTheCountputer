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

    public void GenerateRoom(Vector3 position)
    {
        GameObject newRoom = rooms[Random.Range(0, rooms.Count)];
        Instantiate(newRoom, position, Quaternion.identity);
    }
}
