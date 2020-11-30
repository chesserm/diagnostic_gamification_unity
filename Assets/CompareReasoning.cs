using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HelperNamespace;

public class CompareReasoning : MonoBehaviour
{

    // All components we need to be updating
    GameObject SymptomTitle;
    GameObject CorrectStatus;
    GameObject CorrectReasoning;
    GameObject UserReasoning;

    // Stuctures to track reasoning choices
    List<SymptomState> selectedReasonings;

    int reasoningIndex = 0;
    List<SymptomState> UserSelectedReasoning;

    #region EventHandlers

    // Function to return to Summary page
    public void ReturnButtonHandler()
    {
        SceneManager.LoadScene("PlaySummary");
    }


    // Update panel to compare next reasoning choice
    public void NextButtonHandler()
    {
        // Increase index 
        reasoningIndex += 1;

        int maxReasoningIndex = UserSelectedReasoning.Count - 1;

        if (reasoningIndex > maxReasoningIndex)
        {
            reasoningIndex = 0;
        }

        // Update the UI
        UpdateUI();
        return;
    }



    // Update panel to compare previous reasoning choice
    public void PrevButtonHandler()
    {
        
        // Decrease index 
        reasoningIndex -= 1;
        
        // Check for wrap around
        if (reasoningIndex == -1)
        {
            // Set it to last index of reasoning array
            reasoningIndex = UserSelectedReasoning.Count - 1;
        }

        // Update the UI
        UpdateUI();

        return;
    }

    #endregion


    // All private functions that are used/called from the function that updates the whole UI
    #region HelperFunctions

    // Updates the symptom title at the top of the panel
    private void UpdateSymptomTitle()
    {
        // Get text component of object
        Text textComponent = SymptomTitle.GetComponent<Text>();
        
        // Determine what text to present based upon value
        switch (UserSelectedReasoning[reasoningIndex])
        {
            case (SymptomState.General):
                {
                    textComponent.text = "General Exam";
                    break;
                }
            case (SymptomState.Neck):
                {
                    textComponent.text = "Neck Exam";
                    break;
                }
            case (SymptomState.Heart):
                {
                    textComponent.text = "Heart Exam";
                    break;
                }
            case (SymptomState.Lungs):
                {
                    textComponent.text = "Lungs Exam";
                    break;
                }
            case (SymptomState.Extremities):
                {
                    textComponent.text = "Extremities Exam";
                    break;
                }
            case (SymptomState.Abdomen):
                {
                    textComponent.text = "Abdomen Exam";
                    break;
                }
            case (SymptomState.Oxygen):
                {
                    textComponent.text = "Oxygen Usage";
                    break;
                }
            case (SymptomState.Imaging):
                {
                    textComponent.text = "X-Ray Results";
                    break;
                }
            case (SymptomState.Bloodwork):
                {
                    textComponent.text = "Bloodwork Results";
                    break;
                }
        }

        return;
    }


    // Updates the Status text
    private void UpdateStatus()
    {
        // Get text component of object
        Text textComponent = CorrectStatus.GetComponent<Text>();


        // Get the Symptom currently being compared
        SymptomState symptom = UserSelectedReasoning[reasoningIndex];

        if (CaseInformation.UserReasoning[symptom] == ReasoningState.Correct)
        {
            textComponent.text = "Correct Reasoning";
            textComponent.color = Color.green;
        }
        else
        {
            textComponent.text = "Incorrect Reasoning";
            textComponent.color = Color.red;
        }

        return;
    }


    // Updates the user reasoning text box
    private void UpdateUserReasoning()
    {
        // Get text component of object
        Text textComponent = UserReasoning.GetComponent<Text>();

        // Get the Symptom currently being compared
        SymptomState symptom = UserSelectedReasoning[reasoningIndex];

        // Get the ReasoningValue the user selected for that symptom
        ReasoningState userChoice = CaseInformation.UserReasoning[symptom];

        // Set value of the text
        textComponent.text = PlayLoopData.ReasoningValues[symptom][userChoice];

        return;
    }


    // Updates the correct reasoning text box
    private void UpdateCorrectReasoning()
    {
        // Get text component of object
        Text textComponent = CorrectReasoning.GetComponent<Text>();

        // Get the Symptom currently being compared
        SymptomState symptom = UserSelectedReasoning[reasoningIndex];

        // Set value of the text
        textComponent.text = PlayLoopData.ReasoningValues[symptom][ReasoningState.Correct];

        return;
    }

    #endregion


    // This function will update the UI.
    public void UpdateUI()
    {
        UpdateSymptomTitle();
        UpdateStatus();
        UpdateCorrectReasoning();
        UpdateUserReasoning();

        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Get the list of symptoms the user investigated (and provided reasoning options for)
        UserSelectedReasoning = new List<SymptomState>(CaseInformation.UserReasoning.Keys);

        

        // Initialize all references
        SymptomTitle = GameObject.Find("SymptomText");
        CorrectStatus = GameObject.Find("CorrectStatusText");
        CorrectReasoning = GameObject.Find("CorrectText");
        UserReasoning = GameObject.Find("UserText");

        // Update all UI Components
        UpdateUI();
    }

}
