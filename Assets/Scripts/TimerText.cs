using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{

    public float Tzero;
    public GameObject TextTimer;

    // Update is called once per frame
    void Update()
    {
        Timer = time.time() - Tzero;
        int minutes = Mathf.FloorToInt(Timer / 60F);
	    int seconds = Mathf.FloorToInt(Timer % 60F);
	    int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        TextTimer.GetCompenent<Text>().text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");
    }
}
