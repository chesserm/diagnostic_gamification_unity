using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    //public PatientData patientData;

    private GameObject textObject;

    private Text ageText;


    public void DisplayData()
    {
        ageText.text = "Narratives: " + CaseInformation.patient.Age;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Get new record
        CaseInformation.get_patient_data();


        // Testing passing data between scenes
        UnityEngine.Debug.Log(CaseInformation.patient.Age);
        CaseInformation.patient.Age = 50;
        UnityEngine.Debug.Log(CaseInformation.patient.Age);

        // Setting text box value
        textObject = GameObject.FindGameObjectWithTag("ageText");
        ageText = textObject.GetComponent<Text>();
        //getData();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayData();
    }
}

