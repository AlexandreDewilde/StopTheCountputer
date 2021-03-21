using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoom2 : MonoBehaviour
{
    public float pendingTime = 10f; // Time between 2 new Pictures
    // List of trigs in the room2 
    public List<GameObject> trigs;
    // List of Colors for each trigs
    // For instance trigs[0] Colors[0]
    public List<GameObject> screen_Colors;

    // The list of doors, this is useful to destroy all doors
    // When the puzzle is solved
    public List<GameObject> doors;

    // The number of good move to do in a row to unlock the puzzle
    public int neededRight = 3;
    // Last Time the move to do was updated
    private float lastTime; //

    // The nomber of good moves makes in a row
    private int countRight = 0;

    // The current id -> the move to do (rig to go to)
    private int currentID = 0;

    // Start is called before the first frame update

    void Awake()
    {
        lastTime = Time.time;
        UpdateCurrentID();

    }
    /// <summary>
    /// update the current id -> so a new place to go to
    /// </summary>
    void UpdateCurrentID()
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
            UpdateCurrentID();
        }
        
    }

    /// <summary>
    /// Get the current id -> The rig to go to
    /// </summary>
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
        UpdateCurrentID();
    }

    void ResetRight()
    {
        countRight = 0;
    }
}
