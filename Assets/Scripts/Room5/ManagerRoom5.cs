using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the room5
// It instance random gameObject bits every second
// It creates a puzzle where the player have to hit X bits "green" in a row
// Whoithout touching red bit
// And destroy the doors obstacle when the players unlock the puzzle
/// </summary>
public class ManagerRoom5 : MonoBehaviour
{
    // The number of the right Collision to destroy the doors
    public int neededRightCollision = 5;
    // The Game object of the room, this is useful to know the center of the room
    // And spawn the items
    public GameObject ownRoom;
    // List of doors in the room this is needed to destroy theem when the player unlock the puzzle 
    public List<GameObject> doors;
    // Game Object that represent a bit 0
    public GameObject bit0;
    // Game Object that represent bit 1
    public GameObject bit1;
    private float lastUpdateTime;
    
    private int currentRightCollision = 0;

    void Start()
    {
        lastUpdateTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - lastUpdateTime > 1)
        {
            Vector3 spawnPosition = ownRoom.transform.position + new Vector3(Random.Range(-10,10), Random.Range(-10,10), -0.5f);
            Vector3 spawnPosition2 = ownRoom.transform.position + new Vector3(Random.Range(-10,10), Random.Range(-10,10), -0.5f);
            Rigidbody2D generatedBit = Instantiate(bit0, spawnPosition, Quaternion.identity).GetComponent<Rigidbody2D>();
            Rigidbody2D generatedBit2 = Instantiate(bit1, spawnPosition2, Quaternion.identity).GetComponent<Rigidbody2D>();
            generatedBit.GetComponent<Bit>().gameManager = this;
            generatedBit2.GetComponent<Bit>().gameManager = this;
            generatedBit.velocity = new Vector3(Random.Range(-10f,10f), Random.Range(-10f,10f),0f);
            generatedBit2.velocity = new Vector3(Random.Range(-10f,10f), Random.Range(-10f,10f),0f);
            lastUpdateTime = Time.time;
        }
    }

    public void ApplyCollider(bool isGoodCollision)
    {
        if (isGoodCollision)
        {
            currentRightCollision++;
        }
        else currentRightCollision = 0;
        if (currentRightCollision >= neededRightCollision)
        {
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }
        }
    }
}