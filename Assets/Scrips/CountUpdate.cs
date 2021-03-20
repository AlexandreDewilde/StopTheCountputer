using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountUpdate : MonoBehaviour
{

    public float Timer;
    public Text txt;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60F);
	    int seconds = Mathf.FloorToInt(Timer % 60F);
	    int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");
    }
}
