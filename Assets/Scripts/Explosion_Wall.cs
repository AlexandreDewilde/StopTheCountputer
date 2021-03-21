using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Wall : MonoBehaviour
{

    float time0;

    void Start()
    {
        float time0 = Time.time;
    }

    void Update()
    {
        if (Time.time > time0 + 1)
            Destroy(gameObject);
    }
}
