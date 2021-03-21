using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{


    // The id of the rig, default set to 0
    public int id = 0;

    // The state of the trig
    private bool state;
    // The scripts that manage the room1
    public ManagerRoom1 managerRoom1;
    // the sprite renderer of the gameObject, used to disable the render
    private SpriteRenderer sRender;

    void Awake()
    {
        sRender = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = managerRoom1.GetState(id);
        UpdateColor();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("Trigger");
        // Toggle the state when player hits the Trig
        if (other.gameObject.tag == "Player")
        {
            managerRoom1.ToggleState(id);
            state = !state;
            UpdateColor();
        }   
    }

    /// <summary>
    /// Update the color depending of the state of the trig
    /// </summary>
    private void UpdateColor()
    {
        if (state == true)
        {
            sRender.color = new Color(0,0,255);
        }
        else
        {
            sRender.color = new Color(255,0,0);
        }
    }
}
