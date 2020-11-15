using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlayDiagnose : MonoBehaviour
{

    #region ButtonHandlers

    // Function to return to main play page
    public void BackButtonHandler()
    {
        SceneManager.LoadScene("PlayMain");
    }


    // Function to go to Diagnose page  (with Pneumonia)
    public void CHFButtonHandler()
    {
        CaseInformation.UserDiagnosis = DiagnosisState.CHF;
        SceneManager.LoadScene("PlaySummary");
    }

    // Function to go to Diagnose page  (with Pneumonia)
    public void COPDButtonHandler()
    {
        CaseInformation.UserDiagnosis = DiagnosisState.COPD;
        SceneManager.LoadScene("PlaySummary");
    }

    // Function to go to Diagnose Page (with Pneumonia)
    public void PneumoniaButtonHandler()
    {
        // Set user diagnosis
        CaseInformation.UserDiagnosis = DiagnosisState.Pneumonia;
        SceneManager.LoadScene("PlaySummary");
    }

    #endregion 


    // Start is called before the first frame update
    void Start()
    {
        // Making sure this variable is reset before the user selects a Diagnosis
        CaseInformation.UserDiagnosis = DiagnosisState.Undiagnosed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
