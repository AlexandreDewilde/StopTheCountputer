using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour
{

    public static class Globals
    {
        public static string PlayerName;
    }

    public Text InputField;

    public void PlayGame()
    {

        Globals.PlayerName = InputField.text;
        Debug.Log(Globals.PlayerName);
    }
}
