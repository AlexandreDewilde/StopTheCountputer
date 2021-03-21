using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomName : MonoBehaviour
{

    public string roomName = "NONE";

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.GetComponent<PlayerMethods>().TellPlayerRoomName(roomName);

        }

    }
}
