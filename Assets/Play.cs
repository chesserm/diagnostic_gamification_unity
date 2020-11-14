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


    // Parse the General Exam Data
    public string ParseGeneralExam()
    {

        /* 
         * Uses the following columns from database:
         * Age
         * Gender
         * Past Medical History 1
         * Past Medical History 2
         * Past Medical History 3
         * Tobacco Use
         * Onset of Symptoms
         * Provocating Factors
         * Description of Symptoms
         */

        // Construct constituent strings
        
        int age = CaseInformation.patient.Age;
        string gender = CaseInformation.patient.Gender;

        string pastMed1 = CaseInformation.patient.PastMedHistory1;
        string pastMed2 = CaseInformation.patient.PastMedHistory2;
        string pastMed3 = CaseInformation.patient.PastMedHistory3;

        string tobaccoUse = CaseInformation.patient.TobaccoUse;

        string symptomOnset = CaseInformation.patient.SymptomOnset;
        string symptomDesc = CaseInformation.patient.SymptomDescription;
        string provFactors = CaseInformation.patient.ProvocatingFactors;

        // Provocating factors is often empty, this checks for that
        if (provFactors.Length == 0)
        {
            provFactors = "None";
        }    



        // Construct final string to be displayed (including formatting and units)
        string dataString = "Initial Patient Information:\n\n"
            + "General Information\n"
            + "\t" + "Age: " + age.ToString() + " years old\n"
            + "\t" + "Gender: " + gender + "\n"
            + "\n"
            + "Medical History\n"
            + "\t - " + "Tobacco Use: " + tobaccoUse + "\n\n"
            + "\t - " + pastMed1 + "\n\n"
            + "\t - " + pastMed2 + "\n\n"
            + "\t - " + pastMed3 + "\n\n"
            + "\n\n"
            + "Symptom Information\n\n"
            + "\t" + "Symptom Description: " + symptomDesc + "\n"
            + "\t" + "Symptom Onset: " + symptomOnset + "\n"
            + "\t" + "Provocating Factors: " + provFactors + "\n"

            ;


        return dataString;
    }

    public void DisplayData()
    {

        /* 
         * Initial Information displays the following values from the database:
         * Phsyical Exam - General
         * Temperature
         * Heart Rate
         * Respiratory Rate
         * Blood Pressure
         */
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

