using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPush : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   private void OnMouseDown() 
   {
       _animator.Play("PULL");
   } 
}
