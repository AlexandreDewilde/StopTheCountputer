using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpace : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 generatorVector;
    private GeneralManager generalManager;
    

    void Start()
    {
        generalManager = GameObject.Find("GENERAL_MANAGER").GetComponent<GeneralManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Touched");
            generalManager.GenerateRoom(transform.position, generatorVector);
            Destroy(gameObject);
        }
    }
}
