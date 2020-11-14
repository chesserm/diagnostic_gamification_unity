using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class Statistics : MonoBehaviour
{
    GameObject TextObject;
    Text coins_text;
    int coins;

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

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://diagnostic-gamification-api.herokuapp.com/api/test"));
        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //StreamReader reader = new StreamReader(response.GetResponseStream());
        //string jsonResponse = reader.ReadToEnd();
        //TestMessage info = JsonUtility.FromJson<TestMessage>(jsonResponse);

        //UnityEngine.Debug.Log(info.message);

        //message = info.message;
        //APImessage = GameObject.FindGameObjectWithTag("test_message");
        //messagetext = APImessage.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string key = "block";
        int index = 1;
        while(PlayerPrefs.HasKey(key + index))
        {
            BlockStats CurrentBlock = JsonUtility.FromJson<BlockStats>(PlayerPrefs.GetString(key + index));


            string copdplaceholder = ("COPD Accuracy: " + ((double)CurrentBlock.COPDCorrect / CurrentBlock.COPD) * 100 + "%\n");
            string CHFplaceholder = ("CHF Accuracy: " + ((double)CurrentBlock.CHFCorrect / CurrentBlock.CHF) * 100 + "%\n");
            string Pneumoniaplaceholder = ("Pneumonia Accuracy: " + ((double)CurrentBlock.PneumoniaCorrect / CurrentBlock.Pneumonia) * 100 + "%\n");
            string totalplaceholder = ("Total Accuracy: " + ((double)CurrentBlock.PneumoniaCorrect + (double)CurrentBlock.CHFCorrect + (double)CurrentBlock.COPDCorrect / 10) * 100 + "%\n");

            // check for blocks in which there are no cases of a specific type
            if (CurrentBlock.COPD == 0)
            {
                copdplaceholder = "no COPD cases\n";
            }
            if (CurrentBlock.CHF == 0)
            {
                CHFplaceholder = "no CHF cases\n";
            }
            if (CurrentBlock.Pneumonia == 0)
            {
                Pneumoniaplaceholder = "no Pneumonia cases\n";
            }

            coins_text.text = coins_text.text + "block " + index + "\n" + copdplaceholder + CHFplaceholder + Pneumoniaplaceholder + totalplaceholder + "\n"; 
            index++;
        }
        
        //messagetext.text = message;
    }
}
[System.Serializable]
public class TestMessage
{
    public string message;
}
