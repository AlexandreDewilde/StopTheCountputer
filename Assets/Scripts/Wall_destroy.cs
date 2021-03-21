using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_destroy : MonoBehaviour
{
    public GameObject particles_explosion;

    void OnDestroy()
    {

        Instantiate(particles_explosion, transform.position, Quaternion.identity);

    }
}
