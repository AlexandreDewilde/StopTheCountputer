using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoom2 : MonoBehaviour
{
    public float pendingTime = 10f; // Time between 2 new Pictures
    public List<GameObject> trigs;
    public List<GameObject> screen_Colors;

    public List<GameObject> doors;

    public int neededRight = 3;
    private float lastTime; //

    private int countRight = 0;

    private int currentID = 0;

    // Start is called before the first frame update

    void Awake()
    {
        lastTime = Time.time;
        NewTrig();

    }

    void NewTrig()
    {
        screen_Colors[currentID].GetComponent<SpriteRenderer>().enabled = false;
        int previousID = currentID;
        while (previousID == currentID)
        {
            currentID = Random.Range(0,trigs.Count);
            screen_Colors[currentID].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - pendingTime > lastTime)
        {
            ResetRight();
            // Debug.Log("New Trig to hit");
            lastTime = Time.time;
            NewTrig();
        }
        
    }

    public int GetCurrentId()
    {
        return currentID;
    }

    public void GoodColide()
    {
        Debug.Log(countRight);
        countRight++;
        lastTime = Time.time;
        if (countRight >= neededRight)
        {
            Debug.Log("UNLOCKED");
            foreach (GameObject obj in doors)
            {
                Destroy(obj);
            }
        }
        NewTrig();
    }

    void ResetRight()
    {
        countRight = 0;
    }
}
