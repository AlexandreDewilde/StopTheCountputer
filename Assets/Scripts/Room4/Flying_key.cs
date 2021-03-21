using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_key : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float randAngle = 0;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        randAngle += Random.Range(-5f, 6f);
        transform.Rotate(0.0f, 0.0f, randAngle, Space.Self);
        rb.velocity = Vector3.up * speed;
    }
}
