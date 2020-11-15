using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlayMain : MonoBehaviour
{

    #region ButtonHandlers



    // Function to return to main menu
    public void ReturnToMainMenu()
    {
        // Reset the static class's data so a new case can be fetched on the next entry
        CaseInformation.ResetCaseInformation();

        // Return Player to Main Menu
        SceneManager.LoadScene("MainMenu");
    }


    // Function to go to Diagnose page
    public void DiagnoseButtonHandler()
    {
        SceneManager.LoadScene("PlayDiagnose");
    }


    // Function to go to Investigate page
    public void InvestigateButtonHandler()
    {
        SceneManager.LoadScene("PlaySymptomList");
    }

    #endregion 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
