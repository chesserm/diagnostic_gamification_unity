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

    GameObject totalStats;
    Text totalStats_text;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    // Start is called before the first frame update
    void Start()
    {
        TextObject = GameObject.FindGameObjectWithTag("coins_disp");
        coins_text = TextObject.GetComponent<Text>();

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://diagnostic-gamification-api.herokuapp.com/api/test"));
        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //StreamReader reader = new StreamReader(response.GetResponseStream());
        //string jsonResponse = reader.ReadToEnd();
        //TestMessage info = JsonUtility.FromJson<TestMessage>(jsonResponse);

        //UnityEngine.Debug.Log(info.message);

        BlockStats AllTime = new BlockStats();

        string key = "block";
        int index = 1;
        coins_text.text = "Your diagnostic accuracy over time:\n";
        if (!PlayerPrefs.HasKey(key + index))
        {
            coins_text.text = "Check back here after completeing more cases to see your progress over time!\n ";
        }
        while (PlayerPrefs.HasKey(key + index))
        {

            BlockStats CurrentBlock = JsonUtility.FromJson<BlockStats>(PlayerPrefs.GetString(key + index));

            string copdplaceholder = ("COPD Accuracy: " + RoundToSignificantDigits(((double)CurrentBlock.COPDCorrect / CurrentBlock.COPD) * 100, 2) + "%\n");
            string CHFplaceholder = ("CHF Accuracy: " + RoundToSignificantDigits(((double)CurrentBlock.CHFCorrect / CurrentBlock.CHF) * 100, 2) + "%\n");
            string Pneumoniaplaceholder = ("Pneumonia Accuracy: " + RoundToSignificantDigits(((double)CurrentBlock.PneumoniaCorrect / CurrentBlock.Pneumonia) * 100, 2) + "%\n");
            string totalplaceholder = ("Total Accuracy: " + RoundToSignificantDigits(((double)CurrentBlock.PneumoniaCorrect + (double)CurrentBlock.CHFCorrect + (double)CurrentBlock.COPDCorrect) / 10 * 100, 2) + "%\n");

            // check for blocks in which there are no cases of a specific type
            if (CurrentBlock.COPD == 0)
            {
                copdplaceholder = "no COPD cases attempted\n";
            }
            if (CurrentBlock.CHF == 0)
            {
                CHFplaceholder = "no CHF cases attempted\n";
            }
            if (CurrentBlock.Pneumonia == 0)
            {
                Pneumoniaplaceholder = "no Pneumonia cases attempted\n";
            }

            coins_text.text = coins_text.text + "Cases " + ((index - 1) * 10) + "-" + (index * 10) + "\n" + copdplaceholder + CHFplaceholder + Pneumoniaplaceholder + totalplaceholder + "\n";

            //add this block to the tracking of all blocks
            AllTime.COPDCorrect += CurrentBlock.COPDCorrect;
            AllTime.CHFCorrect += CurrentBlock.CHFCorrect;
            AllTime.PneumoniaCorrect += CurrentBlock.PneumoniaCorrect;
            AllTime.COPD += CurrentBlock.COPD;
            AllTime.CHF += CurrentBlock.CHF;
            AllTime.Pneumonia += CurrentBlock.Pneumonia;

            index++;
        }
        //add non completed blocks to alltime
        if (PlayerPrefs.HasKey("CurrentBlock"))
        {
            BlockStats nonCompletedBlock = JsonUtility.FromJson<BlockStats>(PlayerPrefs.GetString("CurrentBlock"));
            AllTime.COPDCorrect += nonCompletedBlock.COPDCorrect;
            AllTime.CHFCorrect += nonCompletedBlock.CHFCorrect;
            AllTime.PneumoniaCorrect += nonCompletedBlock.PneumoniaCorrect;
            AllTime.COPD += nonCompletedBlock.COPD;
            AllTime.CHF += nonCompletedBlock.CHF;
            AllTime.Pneumonia += nonCompletedBlock.Pneumonia;
        }

        //display the alltime block
        

        string copdplaceholderalltime = "COPD Accuracy: " + RoundToSignificantDigits(((double)AllTime.COPDCorrect / AllTime.COPD) * 100, 2) + "%\n";
        string CHFplaceholderalltime = "CHF Accuracy: " + RoundToSignificantDigits(((double)AllTime.CHFCorrect / AllTime.CHF) * 100, 2) + "%\n";
        string Pneumoniaplaceholderalltime = "Pneumonia Accuracy: " + RoundToSignificantDigits(((double)AllTime.PneumoniaCorrect / AllTime.Pneumonia) * 100, 2) + "%\n";
        string totalplaceholderalltime = "Total Accuracy: " + RoundToSignificantDigits(((double)AllTime.PneumoniaCorrect + (double)AllTime.CHFCorrect + (double)AllTime.COPDCorrect) / (PlayerPrefs.GetInt("DatabaseCaseIndex")) * 100, 2) + "%\n";

        // check for blocks in which there are no cases of a specific type
        if (AllTime.COPD == 0)
        {
            copdplaceholderalltime = "no COPD cases attempted\n";
        }
        if (AllTime.CHF == 0)
        {
            CHFplaceholderalltime = "no CHF cases attempted\n";
        }
        if (AllTime.Pneumonia == 0)
        {
            Pneumoniaplaceholderalltime = "no Pneumonia cases attempted\n";
        }
        if (AllTime.Pneumonia == 0 && AllTime.CHF == 0 && AllTime.COPD == 0)
        {
            totalplaceholderalltime = "no cases attempted\n";
        }

        UnityEngine.Debug.Log(copdplaceholderalltime);

        totalStats = GameObject.FindGameObjectWithTag("test_message");
        totalStats_text = totalStats.GetComponent<Text>();

        totalStats_text.text =  "All time statistics \n" + copdplaceholderalltime + CHFplaceholderalltime + Pneumoniaplaceholderalltime + totalplaceholderalltime + "\n";
    }

    double RoundToSignificantDigits(double d, int digits)
    {
        if (d == 0)
            return 0;

        double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
        return scale * Math.Round(d / scale, digits);
    }

    // Update is called once per frame
    void Update()
    {
        
        //messagetext.text = message;
    }
}
[System.Serializable]
public class TestMessage
{
    public string message;
}
