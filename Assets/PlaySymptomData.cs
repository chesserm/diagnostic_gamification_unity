using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HelperNamespace;

public class PlaySymptomData : MonoBehaviour
{

    // Boolean to check if this is the first viewing of this data
    private bool isFirstViewOfData = true;

    // Boolean to check if selected symptom is one that does not require reasoning
    private bool doesSymptomSkipReasoning = false;

    // Variables to access the GameObjects (image and Textbox)
    GameObject XRayImageObject;
    GameObject TextboxObject;
    Text DataText;


    // Button click event handlers
    #region EventHandlers

    // Function to Continue to Reasoning Page
    public void ContinueButtonHandler()
    {
        // Don't take the user to the reasoning page for dat they've already answered
        // reasoning questions about and don't take them to reasoning if the
        // doesSymptomSkipReasoning is true
        if (isFirstViewOfData && !doesSymptomSkipReasoning)
        {
            SceneManager.LoadScene("PlayReasoning");
        }
        else
        {
            SceneManager.LoadScene("PlayMain");
        }

    }

    #endregion

    // All private helper functions
    // This includes sub regions
    #region HelperFunctions

    // Check to see if the selected symptom data has been viewed before 
    // by checking if the key exists in the selected reasoning dictionary
    private void DetermineIfFirstVisit()
    {
        // I know this can be done in one line, but it's clearer and less prone to bugs this way
        if (CaseInformation.UserReasoning.ContainsKey(CaseInformation.SelectedSymptom))
        {
            isFirstViewOfData = false;
        }
        else
        {
            isFirstViewOfData = true;
        }

        return;
    }

    // Check to see if it is one of the smymptoms that will not require reasoning
    private void isReasoningSkipped()
    {
        if (CaseInformation.SelectedSymptom == SymptomState.Head || CaseInformation.SelectedSymptom == SymptomState.Skin)
        {
            doesSymptomSkipReasoning = true;
        }
        else
        {
            doesSymptomSkipReasoning = false;
        }

        return;
    }


    // Enable the proper game object depending on the selected symptom
    private void EnableProperGameObject()
    {
        // Only set the X-Ray Image to active when the user has selected it
        if (CaseInformation.SelectedSymptom == SymptomState.Imaging)
        {
            // Disable text box
            TextboxObject.SetActive(false);

            // Enable X-Ray Image
            XRayImageObject.SetActive(true);
        }
        else
        {
            // Enable text box
            TextboxObject.SetActive(true);

            // Disable X-Ray Image
            XRayImageObject.SetActive(false);

        }

        return;
    }

    // Function to set the text of the continue button based on current symptom
    // This provides more clarity to the user so they know where they will be taken
    private void DetermineContinueButtonText()
    {
        GameObject button = GameObject.Find("ContinueButton");
        
        // Button should continue to reasoning only if it is the first  view of the
        // data and the symptom being investigated does not require reasoning
        if (isFirstViewOfData && !doesSymptomSkipReasoning)
        {
            button.GetComponentInChildren<Text>().text = "Continue to Reasoning Selection";
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "Finish Reviewing Exam Results";
        }

        return;
    }


    // Data  parsers for each different symptom
    #region DataParsers


    // Parse the General Exam Data
    public string ParseGeneralExam()
    {

        /* 
         * Uses the following columns from database:
         * Phsyical Exam - General
         * Temperature
         * Heart Rate
         * Respiratory Rate
         * Blood Pressure
         */

        // Construct constituent strings
        string examGen = CaseInformation.patient.ExamGeneral;
        double temp = CaseInformation.patient.Temperature;
        double heartRate = CaseInformation.patient.HeartRate;
        double respRate = CaseInformation.patient.RespiratoryRate;
        string bloodPressure = CaseInformation.patient.BloodPressure;


        // Construct final string to be displayed (including formatting and units)
        string dataString = "General Exam Results:\n" 
            + "\t" + examGen
            + "\n\n\n" 
            + "Vitals:\n\n"
            + "\t" + "Temperature: " + temp.ToString() +" C\n\n"
            + "\t" + "Heart Rate: "  + heartRate.ToString() + " Beats per Minute\n\n"
            + "\t" + "Respiratory Rate: " + respRate.ToString() + " Breaths per Minute\n\n"
            + "\t" + "Blood Pressure: " + bloodPressure + " mm Hg\n\n"
            ;


        return dataString;
    }


    // Parse the Head Exam Data
    public string ParseHeadExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Head
         */

        // Construct constituent strings
        string headExam = CaseInformation.patient.ExamHead;

        // Check for edge case of empty string
        if (headExam.Length == 0)
        {
            return "Head exam yielded no data";
        }

        // Parse data string by commas
        string[] bullets = headExam.Split(',');

        // Iterate over each bullet point and display it as such
        string dataString = "Head Exam Results:\n";

        foreach (var bullet in bullets)
        {
            dataString += "\t - " + bullet + "\n";
        }

        return dataString;
    }


    // Parse the Neck Exam Data
    public string ParseNeckExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Neck
         */

        // Construct constituent strings
        string examNeck = CaseInformation.patient.ExamNeck;

        // Construct final string to be displayed (including formatting and units)
        string dataString = "Neck Exam Results:\n"
            + "\t - " + examNeck;

        return dataString;
    }


    // Parse the Heart Exam Data
    public string ParseHeartExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Heart
         */

        // Construct constituent strings
        string examHeart = CaseInformation.patient.ExamHeart;

        // Check for no content in string

        // Iterate over each bullet point and display it as such
        string dataString = "Heart Exam Results:\n";

        // Parse data string by commas
        string[] bullets = examHeart.Contains(".") ? examHeart.Split('.') : examHeart.Split(',');

        foreach (var bullet in bullets)
        {
            dataString += "\t - " + bullet + "\n";
        }

        return dataString;
    }


    // Parse the Lung Exam Data
    public string ParseLungExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Lungs
         */

        // Construct constituent strings
        string examLungs = CaseInformation.patient.ExamLungs;

        // Iterate over each bullet point and display it as such
        string dataString = "Lungs Exam Results:\n";

        // Parse data string by commas
        string[] bullets = examLungs.Contains(".") ? examLungs.Split('.') : examLungs.Split(',');

        foreach (var bullet in bullets)
        {
            dataString += "\t - " + bullet + "\n";
        }

        return dataString;
    }


    // Parse the Extremities Exam Data
    public string ParseExtremitiesExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Extremities
         */

        // Construct constituent strings
        string examExtremitiies = CaseInformation.patient.ExamExtremities;

        // Construct final string to be displayed (including formatting and units)
        string dataString = "Extremities Exam Results:\n"
            + "\t - " + examExtremitiies;

        return dataString;
    }


    // Parse the Abdomen Exam Data
    public string ParseAbdomenExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Abdomen
         */

        // Construct constituent strings
        string examAbdomen = CaseInformation.patient.ExamAbdomen;

        // Iterate over each bullet point and display it as such
        string dataString = "Abdomen Exam Results:\n";

        // Parse data string by commas
        string[] bullets = examAbdomen.Split(',');

        foreach (var bullet in bullets)
        {
            dataString += "\t - " + bullet + "\n";
        }

        return dataString;
    }

    
    // Parse the Oxygen Exam Data
    public string ParseOxygenExam()
    {
        /* 
         * Uses the following columns from database:
         * Oxygen Saturation
         * Amount of oxygen received
         */

        // Construct constituent strings
        string oxygenAmount = CaseInformation.patient.OxygenAmount;
        string oxygenSat = CaseInformation.patient.OxygenSat;

        // Construct final string to be displayed (including formatting and units)
        string dataString = "Overview of Patient Oxygen Information:\n\n"
            + "\t" + "Oxygen Saturation: "         + oxygenSat + "\n\n"
            + "\t" + "Amount of Oxygen Received: " + oxygenAmount
            ;

        return dataString;
    }


    // Parse the Imaging Exam Data
    public string ParseImagingExam()
    {
        return "****************************************\nX-RAY IMAGE SHOULD GO HERE\n****************************************";
    }


    // Parse the Bloodwork Exam Data
    public string ParseBloodworkExam()
    {
        /* 
         * Uses the following columns from database:
         * White blood cell count
         * Hemoglobin
         * Hemacrotit
         * Platelets
         * Sodium
         * Potassium
         * Chloride
         * Bicarbonate
         * BUN
         * Creatinine
         * Glucose
         * BNP
         * AGB - pH
         * ABG - pCO2
         * ABG - pO2
         * Lactate
         */


        // Construct constituent strings
        double wbc = CaseInformation.patient.BloodWBC;
        double hemoglobin = CaseInformation.patient.BloodHemoglobin;
        double hematocrit = CaseInformation.patient.BloodHemacrotit;
        double platelets = CaseInformation.patient.BloodPlatelets;
        double sodium = CaseInformation.patient.BloodSodium;
        double potassium = CaseInformation.patient.BloodPotassium;
        double chloride = CaseInformation.patient.BloodChloride;
        double bicarbonate = CaseInformation.patient.BloodBicarbonate;
        double bun = CaseInformation.patient.BloodBUN;
        double creatinine = CaseInformation.patient.BloodCreatinine;
        double glucose= CaseInformation.patient.BloodGlucose;
        double bnp  = CaseInformation.patient.BloodBNP;

        double abgPH = CaseInformation.patient.BloodABG_ph;
        double abgPCO2 = CaseInformation.patient.BloodABG_pco2;
        double abgPO2 = CaseInformation.patient.BloodABG_po2;
        
        double lactate = CaseInformation.patient.BloodLactate;



        // Construct final string to be displayed (including formatting and units)
        string dataString = "Bloodwork Results:\n\n"
            + "\t" + "ABG-pCO2: " + abgPCO2.ToString() + " mm Hg" + "\n"
            + "\t" + "ABG-pH: " + abgPH.ToString() + "\n"
            + "\t" + "ABG-pO2: " + abgPO2.ToString() + " mm Hg" + "\n"
            + "\t" + "Bicarbonate: " + bicarbonate.ToString() + " mmol/L" + "\n"
            + "\t" + "BNP: " + bnp.ToString() + " pg/mL" + "\n"
            + "\t" + "BUN: " + bun.ToString() + " mg/dL" + "\n"
            + "\t" + "Chloride: " + chloride.ToString() + " mmol/L" + "\n"
            + "\t" + "Creatinine: " + creatinine.ToString() + " mg/dL" + "\n"
            + "\t" + "Glucose: " + glucose.ToString() + " mg/dL" + "\n"
            + "\t" + "Hematocrit: " + hematocrit.ToString() + " %" + "\n"
            + "\t" + "Hemoglobin: " + hemoglobin.ToString() + " g/dL" + "\n"
            + "\t" + "Lactate: " + lactate.ToString() + " mmol/L" + "\n"
            + "\t" + "Platelets: " + platelets.ToString() + " K/uL" + "\n"
            + "\t" + "Potassium: " + potassium.ToString() + " mmol/L" + "\n"
            + "\t" + "Sodium: " + sodium.ToString() + " mmol/L" + "\n"
            + "\t" + "White Blood Cells: " + wbc.ToString() + " K/uL" + "\n"
            ;

        return dataString;
    }


    // Parse the Skin Exam Data
    public string ParseSkinExam()
    {
        /* 
         * Uses the following columns from database:
         * Phsyical Exam - Skin
         */

        // Construct constituent strings
        string examSkin = CaseInformation.patient.ExamSkin;

        // Iterate over each bullet point and display it as such
        string dataString = "Skin Exam Results:\n";

        // Parse data string by commas
        string[] bullets = examSkin.Split(',');

        foreach (var bullet in bullets)
        {
            dataString += "\t - " + bullet + "\n";
        }

        return dataString;
    }



    #endregion


    #endregion


    // Function that uses a switch on the selected Symptom to display the data
    private void DisplaySymptomData()
    {
        switch (CaseInformation.SelectedSymptom)
        {
            case SymptomState.General:
                {
                    DataText.text = ParseGeneralExam();
                    break;
                }
            case SymptomState.Head:
                {
                    DataText.text = ParseHeadExam();
                    break;
                }
            case SymptomState.Neck:
                {
                    DataText.text = ParseNeckExam();
                    break;
                }
            case SymptomState.Heart:
                {
                    DataText.text = ParseHeartExam();
                    break;
                }
            case SymptomState.Lungs:
                {
                    DataText.text = ParseLungExam();
                    break;
                }
            case SymptomState.Extremities:
                {
                    DataText.text = ParseExtremitiesExam();
                    break;
                }
            case SymptomState.Abdomen:
                {
                    DataText.text = ParseAbdomenExam();
                    break;
                }
            case SymptomState.Oxygen:
                {
                    DataText.text = ParseOxygenExam();
                    break;
                }
            case SymptomState.Imaging:
                {
                    DataText.text = ParseImagingExam();
                    break;
                }
            case SymptomState.Bloodwork:
                {
                    DataText.text = ParseBloodworkExam();
                    break;
                }
            case SymptomState.Skin:
                {
                    DataText.text = ParseSkinExam();
                    break;
                }
        } //switch

        return;
    }





    // Start is called before the first frame update
    void Start()
    {
        // Check to see if the selected symptom data has been viewed before 
        // by checking if a reasoning value has been selected for this data
        DetermineIfFirstVisit();

        // Check to see if it is one of the smymptoms that will not require reasoning
        isReasoningSkipped();

        // Determine what text to display on the continue button. This provides
        // more clarity to the user on where they will be taken next.
        // This must be called in Start() AFTER DetermineIfFirstVisit() and
        // isReasoningSkipped() due to the class member variable usage
        DetermineContinueButtonText();

        // Assign the GameObject references to the UI element
        XRayImageObject = GameObject.FindGameObjectWithTag("XRayImage");
        TextboxObject = GameObject.FindGameObjectWithTag("DataText");
        DataText = TextboxObject.GetComponent<Text>();


        // Enable/Disable the proper UI element (X-Ray image or textbox)
        EnableProperGameObject();

        // DisplayText according to symptom data
        DisplaySymptomData();

    }


    // Update is called once per frame
    void Update()
    {
        
    }



    void OnDestroy()
    {
        // If the user has seen this data before, the event handler will skip reasoning and 
        // take them back to the main play page. Therefore, we need to reset the SelectedSymptom
        if (!isFirstViewOfData || doesSymptomSkipReasoning)
        {
            CaseInformation.SelectedSymptom = SymptomState.Nothing;
        }
    }

}
