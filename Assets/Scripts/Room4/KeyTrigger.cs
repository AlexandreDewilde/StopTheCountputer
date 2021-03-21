using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> doors;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("tru");
        if (collider.gameObject.tag == "Player")
        {
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }
            Destroy(gameObject);
        }
    }
}
