using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKey : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float randAngle = 0;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(Random.Range(-250f, 250f), RaKeyndom.Range(-250f,250f), 0f));
    }
}
