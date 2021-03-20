using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerRoom1 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool[] state;
    void Awake()
    {
        state = new bool[] {false, false, false, false, false, false};

    }

    public bool GetState(int id)
    {
        return state[id];
    }

    public void toggleState(int id)
    {
        state[id] = !state[id];   
    }
}
