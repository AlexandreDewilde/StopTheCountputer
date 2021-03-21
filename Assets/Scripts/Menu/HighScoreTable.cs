using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LoginMenu;


/*
With the help of the following video : https://www.youtube.com/watch?v=iAbaqGYdnyI
*/


public class HighScoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;

    private List<Entry> entryList;

    private List<Transform> transformList;


    public class HighscoresList
    {
       public List<Entry> entryList; 
    }


    [System.Serializable]
    public class Entry
    {
        public int score;
        public string name;
    }

    public static void PushScore(string name, float scoredone)
   {
        string strget = PlayerPrefs.GetString("highscore");
        HighscoresList lstjson = JsonUtility.FromJson<HighscoresList>(strget);
        Debug.Log(scoredone);
        Entry ThisPlayer = new Entry() {name = Globals.PlayerName, score = (int)scoredone};

        lstjson.entryList.Add(ThisPlayer);

        string strjson = JsonUtility.ToJson(lstjson);
        PlayerPrefs.SetString("highscore", strjson);
        PlayerPrefs.Save();
   }


    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("entryTemplate");

        entryTemplate.gameObject.SetActive(false);

        transformList = new List<Transform>();

        List<Entry> entryList = new List<Entry>() {
            new Entry{name = "Guillaume", score = 10000}};

        HighscoresList entryListObj = new HighscoresList {entryList = entryList};
        string jsonStr = JsonUtility.ToJson(entryListObj);
        PlayerPrefs.SetString("highscore", jsonStr);
        PlayerPrefs.Save();

        loadJson();
    }


    private void CreateEntry(Entry entry, Transform container, List<Transform> list)
    {
        float templateHeight = 30f;
 
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * list.Count - 27);
        entryTransform.gameObject.SetActive(true);

        int rank = list.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("Pos").GetComponent<Text>().text = rankString;

        string player = entry.name;
        entryTransform.Find("Player").GetComponent<Text>().text = player;

        // Trasforming seconds to mm:ss:ms
        float score = entry.score;
        int minutes = Mathf.FloorToInt(score / 60F);
	    int seconds = Mathf.FloorToInt(score % 60F);
	    int milliseconds = Mathf.FloorToInt((score * 100F) % 100F);
        string txt = minutes.ToString ("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        entryTransform.Find("Score").GetComponent<Text>().text = txt;

        list.Add(entryTransform);
    }


    private void loadJson()
    {   
        Debug.Log(PlayerPrefs.GetString("highscore"));
        string jsonString = PlayerPrefs.GetString("highscore");
        HighscoresList entryListObj = JsonUtility.FromJson<HighscoresList>(jsonString);
        entryList = entryListObj.entryList;

        // Sorting that damn list
        entryList = entryList.OrderBy(w => w.score).ToList();
    
        for (int i = 0; i < entryList.Count; i++)
        {
            if(i <= 10) break;
            CreateEntry(entryList[i], entryContainer, transformList);
        }
    }


}
