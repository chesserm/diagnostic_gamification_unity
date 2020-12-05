using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HelperNamespace;

public class PlayReasoning : MonoBehaviour
{
    // Indices to help randomize where the correct choice is placed (of the four buttons)
    private int correctIndex;
    private int inc1Index;
    private int inc2Index;
    private int inc3Index;

    // Variable that tracks selected button
    private int SelectedButtonIndex;

    // Boolean flag to know if the user can confirm reasoning & continue
    private bool canContinue = false;

    // Variables we will use to find/point to gameobjects
    GameObject ReasoningButton0;
    GameObject ReasoningButton1;
    GameObject ReasoningButton2;
    GameObject ReasoningButton3;
    GameObject ConfirmationButton;

    Text ReasoningButton0Text;
    Text ReasoningButton1Text;
    Text ReasoningButton2Text;
    Text ReasoningButton3Text;



    #region EventHandlers

    // Function to continue to Main Play Page after reasoning is selected
    // This should NOT be added through the Unity UI but called by ConfirmReasoningAndContinue()
    private void ReturnToMainPlay()
    {
        // Add reasoning choice to dictionary
        AddUserReasoningSelection();

        // Reset SelectedSymptom before returning to main play screen
        CaseInformation.SelectedSymptom = SymptomState.Nothing;

        // Return to the main menu
        SceneManager.LoadScene("PlayMain");

        return;
    }


    // Event handler for the confirm reasoning and continue button
    public void ConfirmReasoningAndContinue()
    {
        // Check if the user has selected a resoning choice
        // This gives them a chance to confirm their choice
        if (canContinue)
        {
            ReturnToMainPlay();
        }

        return;
    }


    // Function to return to the symptom data to review the data before selecting reasoning
    public void ReturnToSymptomData()
    {
        SceneManager.LoadScene("PlaySymptomData");
    }


    // Event Handler for the reasoning button #1 (index 0)
    public void ReasoningButton1Handler()
    {
        // Setting selected index
        SelectedButtonIndex = 0;

        // Set the text of this button (index 0) to white and the text of all other buttons to grey
        ReasoningSelectionVisualFeedback(0);

        // Since a reasoning selection has been made, enable the confirmation
        // button (if it hasn't been enabled yet)
        if (!canContinue)
        {
            EnableConfirmReasoningButton();
        }

        return;
    }

    // Event Handler for the reasoning button #2 (index 1)
    public void ReasoningButton2Handler()
    {
        // Setting Selected Index
        SelectedButtonIndex = 1;

        // Set the text of this button (index 1) to white and the text of all other buttons to grey
        ReasoningSelectionVisualFeedback(1);

        // Since a reasoning selection has been made, enable the confirmation
        // button (if it hasn't been enabled yet)
        if (!canContinue)
        {
            EnableConfirmReasoningButton();
        }

        return;
    }

    // Event Handler for the reasoning button #3 (index 2)
    public void ReasoningButton3Handler()
    {
        // Setting Selected Index
        SelectedButtonIndex = 2;

        // Set the text of this button (index 2) to white and the text of all other buttons to grey
        ReasoningSelectionVisualFeedback(2);

        // Since a reasoning selection has been made, enable the confirmation
        // button (if it hasn't been enabled yet)
        if (!canContinue)
        {
            EnableConfirmReasoningButton();
        }

        return;
    }

    // Event Handler for the reasoning button #4 (index 3)
    public void ReasoningButton4Handler()
    {
        // Setting Selected Index
        SelectedButtonIndex = 3;

        // Set the text of this button (index 3) to white and the text of all other buttons to grey
        ReasoningSelectionVisualFeedback(3);

        // Since a reasoning selection has been made, enable the confirmation
        // button (if it hasn't been enabled yet)
        if (!canContinue)
        {
            EnableConfirmReasoningButton();
        }

        return;
    }

    #endregion


    #region HelperFunctions

    // Function to establish the references to the UI elements on screen
    private void SetComponentVariables()
    {
        // Button 1 (index 0 in our code)
        ReasoningButton0 = GameObject.FindGameObjectWithTag("ReasoningButton1");
        ReasoningButton0Text = ReasoningButton0.GetComponent<Text>();

        // Button 2 (index 1 in our code)
        ReasoningButton1 = GameObject.FindGameObjectWithTag("ReasoningButton2");
        ReasoningButton1Text = ReasoningButton1.GetComponent<Text>();

        // Button 3 (index 2 in our code)
        ReasoningButton2 = GameObject.FindGameObjectWithTag("ReasoningButton3");
        ReasoningButton2Text = ReasoningButton2.GetComponent<Text>();

        // Button 4 (index 3 in our code)
        ReasoningButton3 = GameObject.FindGameObjectWithTag("ReasoningButton4");
        ReasoningButton3Text = ReasoningButton3.GetComponent<Text>();

        // ConfirmationButton
        ConfirmationButton = GameObject.Find("ConfirmationButton");

        return;
    }

    
    // Randomly assign which button gets to hold correct reasoning 
    private void RandomlyAssignReasoningIndices()
    {
        // Randomly assign where the correct reasoning choice will go
        System.Random rand = new System.Random();
        correctIndex = rand.Next(0, 4);

        // Assign incorrect reasonings similarly
        inc1Index = (correctIndex + 1) % 4;
        inc2Index = (correctIndex + 2) % 4;
        inc3Index = (correctIndex + 3) % 4;

        return;
    }


    // Set text for the button correspodning to the reasoning assigned to the index passed in
    private void AssignReasoningTextToButton(int reasoningIndex, ReasoningState reasoning)
    {
        string reasoningText = PlayLoopData.ReasoningValues[CaseInformation.SelectedSymptom][reasoning];

        // Reasoning index (what button index did this reasoning text get assigned to)
        switch (reasoningIndex)
        {
            // Set it to button 1 (index 0)
            case 0:
                {
                    ReasoningButton0Text.text = reasoningText;
                    break;
                }
            // Set it to button 2 (index 1)
            case 1:
                {
                    ReasoningButton1Text.text = reasoningText;
                    break;
                }
            // Set it to button 3 (index 2)
            case 2:
                {
                    ReasoningButton2Text.text = reasoningText;
                    break;
                }
            // Set it to button 4 (index 3)
            case 3:
                {
                    ReasoningButton3Text.text = reasoningText;
                    break;
                }
            default:
                {
                    break;
                }
        }

        return;
    }


    // Update dictionary reasoning based on selected button index
    private void AddUserReasoningSelection()
    {
        
        if (SelectedButtonIndex == correctIndex)
        {
            CaseInformation.UserReasoning[CaseInformation.SelectedSymptom] = ReasoningState.Correct;
        }
        else if (SelectedButtonIndex == inc1Index)
        {
            CaseInformation.UserReasoning[CaseInformation.SelectedSymptom] = ReasoningState.Incorrect1;
        }
        else if (SelectedButtonIndex == inc2Index)
        {
            CaseInformation.UserReasoning[CaseInformation.SelectedSymptom] = ReasoningState.Incorrect2;
        }
        else if (SelectedButtonIndex == inc3Index)
        {
            CaseInformation.UserReasoning[CaseInformation.SelectedSymptom] = ReasoningState.Incorrect3;
        }
        return;
    }


    // Helper function to set the color of a button's text
    // Source: https://stackoverflow.com/questions/46962565/how-to-convert-hex-to-colorrgba-with-tryparsehtmlstring
    private void SetButtonTextColor(GameObject button, string hexColor)
    {
        // Create color object
        Color unityColorObject;
        ColorUtility.TryParseHtmlString(hexColor, out unityColorObject);

        // Change color of text component of "Text" child gameobject 
        // source: https://forum.unity.com/threads/change-button-text.424817/
        button.GetComponentInChildren<Text>().color = unityColorObject;

        return;
    }


    // Enable the confirm reasoning button and set its text to white
    private void EnableConfirmReasoningButton()
    {
        // Set color of button's text to white
        string whiteHexColor = "#FFFFFF";

        SetButtonTextColor(ConfirmationButton, whiteHexColor);


        // Set boolean flag to allow confirmation & continuing to true
        canContinue = true;

        return;
    }


    // This function will set selectedButtonNumber's text to white and all other options to grey
    // for visual feedback on the selected option
    private void ReasoningSelectionVisualFeedback(int selectedButtonNumber)
    {
        string whiteHexColor = "#FFFFFF";
        string greyeHexColor = "#797979";

        // Determine what button was selected in range [1,4]
        switch (selectedButtonNumber)
        {
            case 0:
                {
                    // Setting Button1 to white
                    SetButtonTextColor(ReasoningButton0, whiteHexColor);

                    // Setting everything else to grey
                    SetButtonTextColor(ReasoningButton1, greyeHexColor);
                    SetButtonTextColor(ReasoningButton2, greyeHexColor);
                    SetButtonTextColor(ReasoningButton3, greyeHexColor);

                    break;
                }
            case 1:
                {
                    // Setting Button2 to white
                    SetButtonTextColor(ReasoningButton1, whiteHexColor);

                    // Setting everything else to grey
                    SetButtonTextColor(ReasoningButton0, greyeHexColor);
                    SetButtonTextColor(ReasoningButton2, greyeHexColor);
                    SetButtonTextColor(ReasoningButton3, greyeHexColor);
                    break;
                }
            case 2:
                {
                    // Setting Button3 to white
                    SetButtonTextColor(ReasoningButton2, whiteHexColor);

                    // Setting everything else to grey
                    SetButtonTextColor(ReasoningButton0, greyeHexColor);
                    SetButtonTextColor(ReasoningButton1, greyeHexColor);
                    SetButtonTextColor(ReasoningButton3, greyeHexColor);
                    break;
                }
            case 3:
                {
                    // Setting Button4 to white
                    SetButtonTextColor(ReasoningButton3, whiteHexColor);

                    // Setting everything else to grey
                    SetButtonTextColor(ReasoningButton0, greyeHexColor);
                    SetButtonTextColor(ReasoningButton1, greyeHexColor);
                    SetButtonTextColor(ReasoningButton2, greyeHexColor);
                    break;
                }
            default:
                {
                    UnityEngine.Debug.Log("ERROR: Incorrect button num passed to ReasoningSelectionVisualFeedback");
                    break;
                }
        }

        return;
    }

    #endregion



    // Start is called before the first frame update
    void Start()
    {

        // Establish the references to the UI elements on screen
        SetComponentVariables();

        // Determine indices for reasoning text (randomizes positions of reasoning)
        RandomlyAssignReasoningIndices();


        // Actually assign text to buttons
        AssignReasoningTextToButton(correctIndex, ReasoningState.Correct);
        AssignReasoningTextToButton(inc1Index,    ReasoningState.Incorrect1);
        AssignReasoningTextToButton(inc2Index,    ReasoningState.Incorrect2);
        AssignReasoningTextToButton(inc3Index,    ReasoningState.Incorrect3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Run this after the button clicks and before the destroying of the scene
    void OnDestroy()
    {
        
        
    }
}
