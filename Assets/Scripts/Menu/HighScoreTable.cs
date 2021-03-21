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

    public static void PushScore(string name, int score)
   {
        string strget = PlayerPrefs.GetString("highscore");
        HighscoresList lstjson = JsonUtility.FromJson<HighscoresList>(strget);
        
        Entry ThisPlayer = new Entry() {name = Globals.PlayerName, score = 100};

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
            new Entry{name = "Alexandre", score = 5000}, 
            new Entry{name = "Guillaume", score = 10000}, 
            new Entry{name = "Hippolyte", score = 7500},
            new Entry{name = "Guillaume", score = 10000}};

        HighscoresList entryListObj = new HighscoresList {entryList = entryList};
        string jsonStr = JsonUtility.ToJson(entryListObj);
        PlayerPrefs.SetString("highscore", jsonStr);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscore"));

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

        int score = entry.score;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        list.Add(entryTransform);
    }


    private void loadJson()
    {   
        Debug.Log(PlayerPrefs.GetString("highscore"));
        string jsonString = PlayerPrefs.GetString("highscore");
        HighscoresList entryListObj = JsonUtility.FromJson<HighscoresList>(jsonString);
        entryList = entryListObj.entryList;
        Debug.Log(entryList.Count);

        // Sorting that damn list
        entryList = entryList.OrderBy(w => w.score).ToList();
        entryList.Reverse();
    
        foreach (Entry entry in entryList)
        {
            CreateEntry(entry, entryContainer, transformList);
        }
    }


}
