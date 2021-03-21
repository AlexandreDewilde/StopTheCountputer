using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoom5 : MonoBehaviour
{
    // Start is called before the first frame update
    public int neededRightCollision = 5;

    public GameObject ownRoom;
    public List<GameObject> doors;
    public GameObject bit0;
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
            Vector3 spawnPosition = ownRoom.transform.position + new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0);
            Vector3 spawnPosition2 = ownRoom.transform.position + new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0);
            Rigidbody2D generatedBit = Instantiate(bit0, spawnPosition, Quaternion.identity).GetComponent<Rigidbody2D>();
            Rigidbody2D generatedBit2 = Instantiate(bit1, spawnPosition2, Quaternion.identity).GetComponent<Rigidbody2D>();
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