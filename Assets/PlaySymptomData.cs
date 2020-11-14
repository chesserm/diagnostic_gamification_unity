using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlaySymptomData : MonoBehaviour
{
    #region EventHandlers

    // Function to Continue to Reasoning Page
    public void ContinueButtonHandler()
    {
        SceneManager.LoadScene("PlayReasoning");
    }


    #endregion 

    // Start is called before the first frame update
    void Start()
    {

        UnityEngine.Debug.Log("Inside Play Symptom Data");
        UnityEngine.Debug.Log(CaseInformation.patient.Age);
        CaseInformation.patient.Age = 99;
        UnityEngine.Debug.Log(CaseInformation.patient.Age);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
