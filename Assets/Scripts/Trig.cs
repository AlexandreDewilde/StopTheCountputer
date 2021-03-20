using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{

    public int id = 0;
    private bool State;
    private SpriteRenderer sRender;
    void Awake()
    {
        sRender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        state = GetState(id);
        if (state == true)
        {
            sRender.color = new Color(0,255,0);
        }
        else
        {
            sRender.color = new Color(0,0,255);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Toogle the state when player hits the Trig
        if (other.gameObject.tag == "Player")
        {
            toogleState(id);
        }   
    }
}
