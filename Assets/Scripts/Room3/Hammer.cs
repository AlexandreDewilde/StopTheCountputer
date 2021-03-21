using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    //private gameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Hammer");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collid hammer");
            other.gameObject.GetComponent<PlayerMethods>().PickWeapon(1);          

        }    
    }
}
