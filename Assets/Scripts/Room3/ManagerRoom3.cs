using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoom3 : MonoBehaviour
{

    public List<GameObject> malwares = new List<GameObject>();
    public List<GameObject> Doors = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {

        int cnt = 5;

        foreach(GameObject malware in malwares)
        {

            if (malware == null)
                cnt--;

        }

        if (cnt == 0)
        {
            foreach (GameObject door in Doors)
                Destroy(door.gameObject);

        }


    }
}
