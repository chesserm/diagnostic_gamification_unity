using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceProgressBar : MonoBehaviour
{
    private int currentExp;
    private int maxExp;
    private int expToNextLevel;
    Player player;



    // Sets all class variables needed for all other functions
    // Abstracted from Start() to make Start() cleaner
    private void GetPlayerExperienceValues()
    {
        // Establish reference to Player object 
        // (stateless class/script connected to the scene's container gameobject)
        GameObject containerObject = GameObject.Find("ScreenContainer");
        player = containerObject.GetComponent<Player>();

        // Get current experience
        currentExp = player.Experience;

        // Get experience points to next level
        expToNextLevel = player.GetExperienceToNextLevel();

        // Set maxExp based on current exp and remaining exp
        maxExp = currentExp + expToNextLevel;

        return;
    }

    // This region contains the three functions that actually update the UI componenet
    #region UpdateUIFunctions

    // Sets the actual progress bar graphic
    private void SetProgressBarGraphic()
    {
        // Determine the fill percent of the progressbar
        float fillPercent = (float)currentExp / (float)maxExp;

        // Get the ExperienceBar Object
        GameObject experienceBar = GameObject.Find("ExperienceProgressBar");

        // Get the mask child object of ExperienceBar, which is what we are actually changing
        GameObject maskObject = experienceBar.transform.Find("Mask").gameObject;

        // Get the Image component within the "Mask" child object of experienceBar
        // We know this will find the correct Image object because of Depth First Search
        maskObject.GetComponent<Image>().fillAmount = fillPercent;

        return;
    }


    // Sets the textbox for the current level title
    private void SetCurrentLevelText()
    {
        // Get the current experience title from the player class
        string currentTitle = player.GetExperienceLevelString();

        // Get the Experience Title object
        GameObject expTitleText = GameObject.Find("CurrentExperienceTitle");

        // Set the text
        expTitleText.GetComponent<Text>().text = "Current Level:\n" + currentTitle;

        return;
    }


    // Sets the textbox with the amount of exp to the next level
    private void SetExpToNextLevelText()
    {
        // Format remaining experince as string
        string remainingExpAsString = expToNextLevel.ToString();

        // Check to see if experience is >= 1,000 and needs a comma
        if (remainingExpAsString.Length > 3)
        {
            string formattedString = "";
            for (int i = 0; i < remainingExpAsString.Length; ++i)
            {
                // Add comma in correct place
                if (remainingExpAsString.Length - i == 3)
                {
                    formattedString += ",";
                }

                formattedString += remainingExpAsString[i];
            }

            remainingExpAsString = formattedString;
        }
        



        // Get the Textbox object for exp to next level
        GameObject remainingExpText = GameObject.Find("ExpToNextLevel");

        // Set the text (but check for edge case of being at level
        if (expToNextLevel == 0)
        {
            remainingExpText.GetComponent<Text>().text = "Max. Level Reached";
        }
        else
        {
            remainingExpText.GetComponent<Text>().text = "Exp. to next level: " + remainingExpAsString;
        }
        
        return;
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // This must be the first function call in Start()
        GetPlayerExperienceValues();

        // Set the progress bar graphic 
        SetProgressBarGraphic();

        // Set the textboxes for current level and remaining exp
        SetCurrentLevelText();
        SetExpToNextLevelText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
