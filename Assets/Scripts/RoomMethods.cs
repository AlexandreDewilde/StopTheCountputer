using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMethods : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject doorLeft;
    public GameObject doorRight;
    public GameObject doorUp;
    public GameObject doorDown;
    public void DestroyDoor(string doorName)
    {
        if (doorName.Equals("left"))
        {
            Destroy(doorLeft);
        }
        else if (doorName.Equals("right"))
        {
            Destroy(doorRight);
        }
        else if (doorName.Equals("up"))
        {
            Destroy(doorUp);
        }
        else if (doorName.Equals("down"))
        {
            Destroy(doorDown);
        }
    }
}
