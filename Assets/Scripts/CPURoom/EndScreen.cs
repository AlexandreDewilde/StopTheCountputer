using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject TextScore;

    private void Awake()
    {
        float Timer = Time.time;
        Debug.Log(Time.time);
        int minutes = Mathf.FloorToInt(Timer / 60F);
	    int seconds = Mathf.FloorToInt(Timer % 60F);
	    int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        string txt = "Votre temps est de :\n" + minutes.ToString ("00") + "min " + seconds.ToString("00") + "s " + milliseconds.ToString("00") + "ms";
        Debug.Log(txt);
        TextScore.GetComponent<Text>().text = txt;
    }

    public void BackHome()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
