using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerRoom1 : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> doors;
    public int trigNumber;
    private bool[] state;
    private bool[] key;

    void Awake()
    {
        GenerateKey(trigNumber);

        state = new bool[trigNumber];
        for (int i = 0; i < trigNumber; i++)
        {
            state[i] = false;
        }
    }

    private void GenerateKey(int size)
    {
        key = new bool[size];
        for (int i = 0; i < size; i++)
        {
            key[i] = Random.Range(0,2) != 0;
            Debug.Log(key[i]);
        }
    }

    public bool GetState(int id)
    {
        return state[id];
    }

    public void toggleState(int id)
    {
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
        for (int i = 0; i < trigNumber; i++)
        {
            if (state[i] != key[i]) difference++;
        }
        return difference;
    }
}
