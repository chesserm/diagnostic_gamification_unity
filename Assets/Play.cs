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
    
    // Funciton to continue to main play loop
    public void ContinueButtonHandler()
    {
        SceneManager.LoadScene("PlayMain");
    }

    #endregion 

    // UI element references
    private GameObject textObject;
    private Text initialText;


    // Parse the General Exam Data
    public void DisplayData()
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
            + "\t - " + "Tobacco Use: " + tobaccoUse + "\n";


        // Check past med history for content before adding them
        if (pastMed1.Length != 0)
        {
            dataString += "\t - " + pastMed1 + "\n";
        }

        if (pastMed2.Length != 0)
        {
            dataString += "\t - " + pastMed2 + "\n";
        }

        if (pastMed3.Length != 0)
        {
            dataString += "\t - " + pastMed3 + "\n";
        }


            dataString += "\n\n"
            + "Symptom Information\n\n"
            + "\t" + "Symptom Description: " + symptomDesc + "\n\n"
            + "\t" + "Symptom Onset: " + symptomOnset + "\n\n"
            + "\t" + "Provocating Factors: " + provFactors + "\n\n"
            ;

        initialText.text = dataString;

        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Establish UI element Gameobject reference
        textObject = GameObject.FindGameObjectWithTag("InitialDataText");
        initialText = textObject.GetComponent<Text>();

        // Get new record from Database
        CaseInformation.get_patient_data();

        // Display Initial Data on the Play page
        DisplayData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

