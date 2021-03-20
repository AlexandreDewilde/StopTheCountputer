using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{

    public int id = 0;
    private bool state;
    private ManagerRoom1 managerRoom1;
    private SpriteRenderer sRender;
    void Awake()
    {
        sRender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        managerRoom1 = GameObject.Find("ManagerRoom1").GetComponent<ManagerRoom1>();
        state = managerRoom1.GetState(id);
        UpdateColor();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Toogle the state when player hits the Trig
        if (other.gameObject.tag == "Player")
        {
            managerRoom1.toggleState(id);
            state = !state;
            UpdateColor();
        }   
    }

    private void UpdateColor()
    {
        if (state == true)
        {
            sRender.color = new Color(0,255,0);
        }
        else
        {
            sRender.color = new Color(0,0,255);
        }
    }
}
