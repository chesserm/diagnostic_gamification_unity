using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlaySymptomData : MonoBehaviour
{

    // Boolean to check if this is the first viewing of this data
    private bool isFirstViewOfData = true;

    #region EventHandlers

    // Function to Continue to Reasoning Page
    public void ContinueButtonHandler()
    {
        // Don't take the user to the reasoning page for dat they've already answered
        // reasoning questions about
        if (isFirstViewOfData)
        {
            SceneManager.LoadScene("PlayReasoning");
        }
        else
        {
            SceneManager.LoadScene("PlayMain");
        }
        
    }

    #endregion


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

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // Check to see if the selected symptom data has been viewed before 
        DetermineIfFirstVisit();


    }


    // Update is called once per frame
    void Update()
    {
        
    }



    void OnDestroy()
    {
        // If the user has seen this data before, the event handler will skip reasoning and 
        // take them back to the main play page. Therefore, we need to reset the SelectedSymptom
        if (!isFirstViewOfData)
        {
            CaseInformation.SelectedSymptom = SymptomState.Nothing;
        }
    }

}
