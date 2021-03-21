using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{

    public static float Tzero;
    public float Timer;
    public GameObject TextTimer;
    
    // Update is called once per frame
    void Update()
    {
        Tzero = 0;
        float Timer = Time.time - Tzero;
        int minutes = Mathf.FloorToInt(Timer / 60F);
	    int seconds = Mathf.FloorToInt(Timer % 60F);
	    int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        string txt = minutes.ToString ("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        TextTimer.GetComponent<Text>().text = txt;
    }
}
