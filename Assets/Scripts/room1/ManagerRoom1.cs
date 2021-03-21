using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerRoom1 : MonoBehaviour
{

    // The list of doors gameObject in the Room1
    public List<GameObject> doors;
    // The numbers of Trig in the room
    public int trigNumber; // The
    // The state of trigs
    private bool[] state;
    // The key the player should solve
    private bool[] key;

    void Awake()
    {
        GenerateKey();

        CreateState();
    }

    /// <summary>
    /// Generate an array of boolean of size Trig, that will be 
    /// the key the players have to solve
    /// </summary>
    private void GenerateKey()
    {
        key = new bool[trigNumber];
        for (int i = 0; i < trigNumber; i++)
        {
            key[i] = Random.Range(0,2) != 0;
            Debug.Log(key[i]);
        }
    }

    /// <summary>
    /// Generate an array of boolean of size Trig set to False,
    ///that will be the state of the trig
    /// </summary>
    private void CreateState()
    {
        state = new bool[trigNumber];
        for (int i = 0; i < trigNumber; i++)
        {
            state[i] = false;
        }
    }

    /// <summary>
    /// Return the difference between the key and the state
    /// </summary>
    private int CompareKeyState()
    {
        int difference = 0;
        for (int i = 0; i < trigNumber; i++)
        {
            if (state[i] != key[i]) difference++;
        }
        return difference;
    }

    private void DestroyAllDoors()
    {
        foreach (GameObject door in doors)
        {
            Destroy(door);
        }
    }

    /// <summary>
    /// Return the state of one trig identified by id
    /// </summary>
    /// <param name="id">The id of the Trig.</param>
    public bool GetState(int id)
    {
        return state[id];
    }


    /// <summary>
    /// Toogle the state of the trig specified by id
    /// and if it's solved destroy the doors
    /// </summary>
    /// <param name="id">The id of the Trig.</param>
    public void ToggleState(int id)
    {
        state[id] = !state[id];
        int difference = CompareKeyState();
        if (difference == 0)
        {
            DestroyAllDoors();
        }
    }
    
}
