using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using HelperNamespace;

public class Play : MonoBehaviour
{
    #region ButtonHandlers
    
    // Function to return to main menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // Funciton to continue to main play loop
    public void ContinueButtonHandler()
    {
        SceneManager.LoadScene("PlayMain");
    }

    #endregion 

    // Variable to track data from database
    public PatientData patientData;

    private GameObject textObject;

    private Text ageText;

    // This is the function where the database access will happen
    public void getData()
    {
        patientData = get_patient_data();
    }


    // Function to do API call
    private PatientData get_patient_data()
    {
        //replace X with our api url
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://diagnostic-gamification-api.herokuapp.com/v1/cases/208"));
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        UnityEngine.Debug.Log(jsonResponse);
        
        PatientData data = JsonUtility.FromJson<PatientData>(jsonResponse);

        string myVariable = JsonUtility.ToJson(data);
        UnityEngine.Debug.Log(data.Narratives);
        return data;
    }


    public void DisplayData()
    {
        ageText.text = "Narratives: " + patientData.Narratives;
    }


    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("ageText");
        ageText = textObject.GetComponent<Text>();
        getData();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayData();
    }
}

