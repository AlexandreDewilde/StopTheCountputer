using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoginMenu;

public class CPUPush : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private float timeEnd;
    private Transform EndScreenContainer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   private void OnTriggerEnter2D(Collider2D coll) 
   {
        if (coll.gameObject.tag == "Player")
        {
            _animator.Play("PULL");
            timeEnd = Time.time;
            end();
        }
       
   }

    private void end()
    {
        Debug.Log("CpuTriggered");
        EndScreenContainer = transform.Find("EndScreen");
        EndScreenContainer.gameObject.SetActive(true);
        HighScoreTable.PushScore(Globals.PlayerName, 100);
    }
}
