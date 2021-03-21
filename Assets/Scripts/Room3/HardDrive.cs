using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDrive : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.rotation = rb.rotation + speed;
        //Debug.Log(rb.rotation);
    }
}
