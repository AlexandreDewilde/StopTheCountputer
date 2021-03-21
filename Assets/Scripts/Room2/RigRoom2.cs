using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigRoom2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int id = 0;
    public ManagerRoom2 managerRoom2;
    void Start()
    {
        
    }

    // Update is called once per fram
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered rig2");
        if (other.gameObject.tag == "Player")
        {
            if (id == managerRoom2.GetCurrentId())
            {
                managerRoom2.GoodColide();
            }
        }   
    }
}
