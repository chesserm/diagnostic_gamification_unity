using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        // Hardcoding values based upon one data record given
        patientData = new PatientData();

        #region InitialData
        patientData.InitialData = new List<String>();
        patientData.InitialData.Add("74"); // Age
        patientData.InitialData.Add("male"); // Gender
        patientData.InitialData.Add("heart failure"); // Past Med History 1
        patientData.InitialData.Add("coronary artery disease"); // Past Med History 2
        patientData.InitialData.Add("COPD"); // Past Med History 3
        patientData.InitialData.Add("current"); // Tobacco Use
        patientData.InitialData.Add("3 days"); // Onset of symptoms
        patientData.InitialData.Add("constant"); // Duration of Symptoms
        patientData.InitialData.Add("exertion"); // Provocating Factors
        patientData.InitialData.Add("chest heaviness"); // Description of Symptoms
        patientData.InitialData.Add("severe"); // Severity of Symptoms
        patientData.InitialData.Add("none"); // Relieving Factors

        #endregion

        #region GeneralExamInfo

        patientData.GeneralExamData = new List<String>();
        patientData.GeneralExamData.Add("38.4"); // Temperature
        patientData.GeneralExamData.Add("121"); // Heart Rate
        patientData.GeneralExamData.Add("24"); // Respiratory Rate
        patientData.GeneralExamData.Add("104/53"); // Blood Pressure
        patientData.GeneralExamData.Add("awake, alert, oriented x 2"); // Observations

        #endregion

        #region OtherExamInfo

        patientData.HeadData = "pupils equal and reactive, dry mucous membranes";
        patientData.NeckData = "No jugular venous distention";
        patientData.LungData = "Crackles in the right lung";
        patientData.ExtremitiesData = "no edema";
        patientData.SkinData = "warm, dry";
        patientData.AbdomenData = "soft, nontender, nondistended";

        #endregion

        #region OxygenInfo
        patientData.OxygenData = new List<String>();
        patientData.OxygenData.Add("91%"); // oxygen saturation
        patientData.OxygenData.Add("4 liters per minute"); // Amount of Oxygen received

        #endregion

        #region BloodworkData

        patientData.BloodworkData = new List<double>();
        patientData.BloodworkData.Add(14.2); // White blood cells
        patientData.BloodworkData.Add(13.6); // Hemoglobin
        patientData.BloodworkData.Add(40.1); // Hematocrit
        patientData.BloodworkData.Add(247); // Platelets
        patientData.BloodworkData.Add(137); // Sodium
        patientData.BloodworkData.Add(4.2); // Potassium
        patientData.BloodworkData.Add(104); // Chloride
        patientData.BloodworkData.Add(21); // Bicarbonate
        patientData.BloodworkData.Add(24); // BUN
        patientData.BloodworkData.Add(1.6); // Creatinine
        patientData.BloodworkData.Add(137); // Glucose
        patientData.BloodworkData.Add(37); // BNP
        patientData.BloodworkData.Add(7.35); // ABG - pH
        patientData.BloodworkData.Add(39); // ABG - pCO2
        patientData.BloodworkData.Add(71); // ABG - pO2
        patientData.BloodworkData.Add(2.4); // Lactate

        #endregion

        // No image given for sample record
        patientData.XRayImage = null;

        // Making up diagnosis since one was not given
        patientData.Diagnosis = DiagnosisState.Pneumonia;

        return;
    }


    public void DisplayData()
    {
        ageText.text = "Age: " + patientData.InitialData[0];
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
