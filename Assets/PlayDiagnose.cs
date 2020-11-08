using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDiagnose : MonoBehaviour
{

    #region ButtonHandlers

    // Function to return to main menu
    public void BackButtonHandler()
    {
        SceneManager.LoadScene("PlayMain");
    }


    // Function to go to Diagnose page  (with Pneumonia)
    public void CHFButtonHandler()
    {
        SceneManager.LoadScene("PlaySummary");
    }

    // Function to go to Diagnose page  (with Pneumonia)
    public void COPDButtonHandler()
    {
        SceneManager.LoadScene("PlaySummary");
    }

    // Function to go to Diagnose Page (with Pneumonia)
    public void PneumoniaButtonHandler()
    {
        SceneManager.LoadScene("PlaySummary");
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
