using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMain : MonoBehaviour
{

    #region ButtonHandlers

    // Function to return to main menu
    public void ReturnToMainMenu()
    {
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
        SceneManager.LoadScene("PlayInvestigate");
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
