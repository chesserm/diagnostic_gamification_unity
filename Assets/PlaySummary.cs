using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlaySummary : MonoBehaviour
{

    #region MemberVariables

    // Variables that store the amount awarded to user 
    private int coinsAwarded;
    private int expAwarded;

    // Variable that scales awards based on difficulty of case
    private int difficultyMod;

    // Variable to store whether or not the user diagnosis was correct
    private bool wasUserCorrect = false;

    #endregion


    // Button handler functions
    #region ButtonHandlers

    // Function to return to main menu
    public void ContinueButtonHandler()
    {
        // Reset the static player data so the next entry into 
        // the Play loop is a clean slate
        CaseInformation.ResetCaseInformation();

        SceneManager.LoadScene("MainMenu");
    }


    // Function to go to reasoning page
    public void ReasoningButtonHandler()
    {
        SceneManager.LoadScene("CompareReasoning");
    }

    #endregion



    // All private functions used only here
    // Contains subregions for award system and display functions
    #region HelperFunctions


    // All functions that deal with the award system
    #region AwardSystem

    // Determine the difficulty modifier to be applied to reward amounts
    private void DetermineDifficultyModifier()
    {
        string difficulty = CaseInformation.patient.Difficulty;
        difficulty = difficulty.ToLower();
        
        if (difficulty == "easy")
        {
            difficultyMod = 1;
        }
        else if (difficulty == "medium")
        {
            difficultyMod = 2;
        }
        else if (difficulty == "hard")
        {
            difficultyMod = 3;
        }
        else
        {
            // Handles potential DB error for Difficulty field
            difficultyMod = 1;
        }

        return;
    }

    // Determine award for the user's Diagnostic accuracy
    private void DetermineDiagnosisReward()
    {
        if (wasUserCorrect)
        {
            coinsAwarded = 100;
            expAwarded = 250;
        }
        else
        {
            // Base rewards
            coinsAwarded = 50;
            expAwarded = 100;
        }

        // Scale based on difficulty
        coinsAwarded *= difficultyMod;
        expAwarded *= difficultyMod;

        return;

    }


    // Determines how much experience and coins to award user with for
    // reasoning choices
    private void DetermineReasoningReward()
    {
        // Number of symptoms the user could have investigated (that have reasoning)
        int maxNumSymptoms = 9;

        // Get size of reasoning dictionary to determine the number of 
        // symptoms the user chose to investigate
        int numSymptomsInvestigated = CaseInformation.UserReasoning.Count;


        // Determine the number of symptoms where the user selected
        // the correct reasoning choice
        int numCorrectReasonings = 0;

        List<SymptomState> reasoningChoices = new List<SymptomState>(CaseInformation.UserReasoning.Keys);
        foreach (var symptom in reasoningChoices)
        {
            if (CaseInformation.UserReasoning[symptom] == ReasoningState.Correct)
            {
                numCorrectReasonings += 1;
            }
        }

        // Add rewards for correct reasoning
        // Not impacted by difficulty mod since reasoning choices are independent of difficulty
        coinsAwarded += (numCorrectReasonings * 10);
        expAwarded   += (numCorrectReasonings * 25);


        // Bonus for needing minimal information to make the diagnosis
        // 9  * (number divisible by 3 and 2)
        int coinInfobonus =  (maxNumSymptoms * (60 / difficultyMod)) -  ((60 / difficultyMod) * numSymptomsInvestigated);
        int expInfoBonus  =  (maxNumSymptoms * (90 / difficultyMod)) -  ((90 / difficultyMod) * numSymptomsInvestigated);

        coinsAwarded += coinInfobonus;
        expAwarded += expInfoBonus;

        return;
    }


    // Function that actually awards player and updates player prefs
    private void AwardPlayer()
    {
        // Establish reference to Player object 
        // (stateless class/script connected to an otherwise empty GameObject)
        GameObject containerObject = GameObject.FindGameObjectWithTag("ContainerObject");
        Player player = containerObject.GetComponent<Player>();


        // Parameter passed into player class works as follows
        // 'c' = COPD
        // 'p' = Pnueomonia
        // 'h' = CHF
        char caseType = 'e';
        switch (CaseInformation.TrueDiagnosis)
        {
            case (DiagnosisState.CHF):
            {
                caseType = 'h';
                break;
            }
            case (DiagnosisState.COPD):
            {
                caseType = 'c';
                break;
            }
            case (DiagnosisState.Pneumonia):
            {
                caseType = 'p';
                break;
            }
    
        }
        
        // Use function from player class to update PlayerPrefs based on these values
        player.CompleteCase(coinsAwarded, expAwarded, caseType, wasUserCorrect);
        return;
    }


    #endregion


    // All functions used to display information on the screen
    #region DisplayFunctions


    // Update the text of the UI components for the Diagnoses
    private void DisplayDiagnosis()
    {
        UnityEngine.Debug.Log(CaseInformation.UserDiagnosis);
        UnityEngine.Debug.Log(CaseInformation.TrueDiagnosis);

        GameObject userDiagnosisTextbox = GameObject.FindGameObjectWithTag("UserDiagnosis");
        Text userDiagnosisText = userDiagnosisTextbox.GetComponent<Text>();
        userDiagnosisText.text = "" + CaseInformation.UserDiagnosis;

        if (wasUserCorrect)
        {
            userDiagnosisText.color = Color.green;
        }
        else
        {
            // The default red color is quite bright, so we are instead using 
            // a hexidecimal code for red
            string redHexColor = "#C03232";
            Color unityColorObject;
            ColorUtility.TryParseHtmlString(redHexColor, out unityColorObject);

            userDiagnosisText.color = unityColorObject;
        }



        GameObject correctDiagnosisTextbox = GameObject.FindGameObjectWithTag("CorrectDiagnosis");
        Text correctDiagnosisText = correctDiagnosisTextbox.GetComponent<Text>();
        correctDiagnosisText.text = "" + CaseInformation.TrueDiagnosis;
    }


    // Update the text of the UI component for the expert comments
    private void DisplayExpertComment()
    {
        GameObject expertCommentTextBox = GameObject.FindGameObjectWithTag("ExpertComments");
        Text expertCommentsText = expertCommentTextBox.GetComponent<Text>();

        UnityEngine.Debug.Log(CaseInformation.patient.ExpertComments);

        expertCommentsText.text = CaseInformation.patient.ExpertComments;
    }


    // Update the text of the UI component for the rewards
    private void DisplayRewards()
    {
        GameObject coinsTextObject = GameObject.FindGameObjectWithTag("Coins");
        Text coinsText = coinsTextObject.GetComponent<Text>();
        coinsText.text = coinsAwarded.ToString();

        GameObject expTextObject = GameObject.FindGameObjectWithTag("Experience");
        Text expText = expTextObject.GetComponent<Text>();
        expText.text = expAwarded.ToString() + " exp.";


    }
    #endregion


    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // Determine if user got diagnosis correct
        wasUserCorrect = CaseInformation.UserDiagnosis == CaseInformation.TrueDiagnosis;


        // Assign awards. 
        // *********** Do not change order of function calls *********** 
        // DetermineDiagnosisReward() assigns default values for rewards
        // and depends on DetermineDifficultyModifier()
        DetermineDifficultyModifier();
        DetermineDiagnosisReward();
        DetermineReasoningReward();

        // Actually award player (and update PlayerPrefs)
        // but only do so once for this case
        if (!CaseInformation.hasPlayerBeenAwarded)
        {
            AwardPlayer();
            CaseInformation.hasPlayerBeenAwarded = true;
        }
        


        // Display summary results on screen
        DisplayDiagnosis();
        DisplayExpertComment();
        DisplayRewards();


        // Check to see if user did not investigate any data with reasoning
        if (CaseInformation.UserReasoning.Count == 0)
        {
            GameObject reasoningButton = GameObject.Find("ReasoningButton");
            reasoningButton.SetActive(false);
        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }



 
}
