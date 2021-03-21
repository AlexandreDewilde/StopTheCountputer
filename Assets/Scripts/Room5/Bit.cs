using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : MonoBehaviour
{
    public float lifeTime;
    public ManagerRoom5 gameManager;
    private bool isGood;
    private float initTime;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        isGood = Random.Range(0,3) != 0;
        initTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isGood) spriteRenderer.color = new Color(0,255,0);
        else spriteRenderer.color = new Color(255, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - initTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.ApplyCollider(isGood);
        }
        Destroy(gameObject);
    }

}