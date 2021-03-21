using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_ventilo : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        rb.rotation += speed;

    }
}
