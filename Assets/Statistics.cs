using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net;
using System;
using System.IO;

public class Statistics : MonoBehaviour
{
    GameObject TextObject;
    Text coins_text;
    int coins;

    GameObject APImessage;
    Text messagetext;
    string message;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("NumCoins");
        TextObject = GameObject.FindGameObjectWithTag("coins_disp");
        coins_text = TextObject.GetComponent<Text>();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://diagnostic-gamification-api.herokuapp.com/api/test"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        TestMessage info = JsonUtility.FromJson<TestMessage>(jsonResponse);

        UnityEngine.Debug.Log(info.message);

        message = info.message;
        APImessage = GameObject.FindGameObjectWithTag("test_message");
        messagetext = APImessage.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coins_text.text = "coins: " + coins.ToString();
        messagetext.text = message;
    }
}
[System.Serializable]
public class TestMessage
{
    public string message;
}
