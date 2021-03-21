using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoginMenu;

public class CPUPush : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private float timeEnd;
    private GameObject EndScreenContainer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

   private void OnTriggerEnter2D(Collider2D coll) 
   {
        Debug.Log("PUUUUUULL");
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
        EndScreenContainer = GameObject.Find("EndScreen");
        EndScreenContainer.GetComponent<Canvas>().enabled = true;
        Debug.Log(Time.time - TimerText.Tzero);
        HighScoreTable.PushScore(Globals.PlayerName, Time.time - TimerText.Tzero);
    }
}
