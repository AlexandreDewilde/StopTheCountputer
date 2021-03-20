using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerRoom1 : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> doors;
    private int rigNumber;
    private bool[] state;
    private bool[] key;
    void Awake()
    {
        rigNumber = doors.Count;
        
        GenerateKey(rigNumber);
        Debug.Log(key);
        state = new bool[] {false, false, false, false, false, false};

    }

    private void GenerateKey(int size)
    {
        key = new bool[size];
        for (int i = 0; i < size; i++)
        {
            key[i] = Random.Range(0,1) != 0;
        }
    }

    public bool GetState(int id)
    {
        return state[id];
    }

    public void toggleState(int id)
    {
        Debug.Log(state);
        state[id] = !state[id];
        int difference = CompareKeyState();
        if (difference == 0)
        {
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }
        }
    }

    private int CompareKeyState()
    {
        int difference = 0;
        for (int i = 0; i < state.Length; i++)
        {
            if (state[i] != key[i]) difference++;
        }
        return difference;
    }
}
