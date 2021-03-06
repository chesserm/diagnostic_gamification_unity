﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Net;
using System;
using System.Runtime;
using System.IO;
//using Assets;
using System.Runtime.Serialization;

public class Player : MonoBehaviour
{
	public int NumCoins
	{
		get { return PlayerPrefs.GetInt("NumCoins"); }
	}
	public int Experience
	{
		get { return PlayerPrefs.GetInt("Experience"); }
	}
	public int NextCase
	{
		get { return PlayerPrefs.GetInt("NextCase"); }
	}
	public int total_correct
	{
		get { return PlayerPrefs.GetInt("total_correct"); }
	}
	public string Block
    {
		get { return PlayerPrefs.GetString("CurrentBlock"); }
	}



// Start is called before the first frame update
void Start()
    {
		// if player prefs hasnt been populated initialize the values
		if(!PlayerPrefs.HasKey("NumCoins"))
        {
			PlayerPrefs.SetInt("NumCoins", 0);
			PlayerPrefs.SetInt("Experience", 0);
			PlayerPrefs.SetInt("ExpLevel", 0);
			PlayerPrefs.SetInt("NextCase", 0);
			PlayerPrefs.SetInt("total_correct", 0);
			BlockStats firstBlock = new BlockStats();
			PlayerPrefs.SetString("CurrentBlock", JsonUtility.ToJson(firstBlock));
		}
	}

	// Function that is called from PlaySummary when the user has completed diagnosing a case
	public void CompleteCase(int coins, int xp, char casetype, bool correct)
    {
		// Update the values of the player based upon rewards from the diagnostic session
		PlayerPrefs.SetInt("NumCoins", this.NumCoins + coins);
		PlayerPrefs.SetInt("Experience", this.Experience + xp);
		PlayerPrefs.SetInt("NextCase", this.NextCase + 1);

		// Update experience level using helper below
		// This must be called AFTER the Experience value is updated above
		UpdateExperienceLevel();

		BlockStats CurrentBlock = JsonUtility.FromJson<BlockStats>(this.Block);
		if (casetype == 'c')
		{
			CurrentBlock.COPD++;
			if (correct) CurrentBlock.COPDCorrect++;
		}
		if (casetype == 'h')
		{
			CurrentBlock.CHF++;
			if (correct) CurrentBlock.CHFCorrect++;
		}
		if (casetype == 'p')
		{
			CurrentBlock.Pneumonia++;
			if (correct) CurrentBlock.PneumoniaCorrect++;
		}
		if (NextCase % 10 == 0)
        {
			string key = "block" + (NextCase / 10);
			PlayerPrefs.SetString( key, JsonUtility.ToJson(CurrentBlock));
			
			UnityEngine.Debug.Log(key);
			UnityEngine.Debug.Log(PlayerPrefs.GetString(key));

			CurrentBlock = new BlockStats();
        }
		PlayerPrefs.SetString("CurrentBlock", JsonUtility.ToJson(CurrentBlock));
	}


	// Testing function used to test when cases are complete
	public void callplayercomplete()
	{
		this.CompleteCase(10, 10, 'c', true);
	}


	// Functions dealing with the implementation of the level system
    #region ExperienceSystem 

    // Function to be called when a case is completed to update the player's level
    private void UpdateExperienceLevel()
    {
		int currentExp = PlayerPrefs.GetInt("Experience");

		// The order of these if statements must be exactly as-is for this to work
		// as it is currently written.
		if (currentExp < 1000)
        {
			// Level 0: Undergrad
			//  [0, 1,000) exp
			PlayerPrefs.SetInt("ExpLevel", 0);
        }
		else if (currentExp < 3000)
        {
			// Level 1: MedStudent
			//  [1,000, 3,000) exp
			PlayerPrefs.SetInt("ExpLevel", 1);
		}
		else if (currentExp < 7500)
        {
			// Level 2: ResidencyPhysician
			//  [3,000, 7,500) exp
			PlayerPrefs.SetInt("ExpLevel", 2);
		}
		else if (currentExp < 10000)
        {
			// Level 3: Physician
			//  [7,500, 10,000) exp
			PlayerPrefs.SetInt("ExpLevel", 3);
		}
		else
        {
			// Level 4 (max level): ExpertSpecialist
			//  10,000+ exp
			PlayerPrefs.SetInt("ExpLevel", 4);
		}

		return;
    }


	// Public function to get the player's level title (as a string)
	public string GetExperienceLevelString()
    {
		int levelNum = PlayerPrefs.GetInt("ExpLevel");

		switch(levelNum)
        {
			case 0:
                {
					// Level 0: Undergrad
					//  [0, 1,000) exp
					return "Undergraduate Student";
                }
			case 1:
				{
					// Level 1: MedStudent
					//  [1,000, 3,000) exp
					return "Medical Student";
				}
			case 2:
				{
					// Level 2: ResidencyPhysician
					//  [3,000, 7,500) exp
					return "Residency Physician";
				}
			case 3:
				{
					// Level 3: Physician
					//  [7,500, 10,000) exp
					return "Physician";
				}
			case 4:
				{
					// Level 4 (max level): ExpertSpecialist
					//  10,000+ exp
					return "Expert Specialist";
				}
			default:
                {
					return "ERROR GETTING LEVEL TITLE. LEVEL OUT OF RANGE. SEE PLAYER CLASS";
                }
		}
	}

	// Returns title for level based on number
	// this differs from the above function by not using the player's level implicitly
	public string GetTitleForItem(int levelNum)
	{
		switch (levelNum)
		{
			case 0:
				{
					// Level 0: Undergrad
					//  [0, 1,000) exp
					return "Undergraduate Student";
				}
			case 1:
				{
					// Level 1: MedStudent
					//  [1,000, 3,000) exp
					return "Medical Student";
				}
			case 2:
				{
					// Level 2: ResidencyPhysician
					//  [3,000, 7,500) exp
					return "Residency Physician";
				}
			case 3:
				{
					// Level 3: Physician
					//  [7,500, 10,000) exp
					return "Physician";
				}
			case 4:
				{
					// Level 4 (max level): ExpertSpecialist
					//  10,000+ exp
					return "Expert Specialist";
				}
			default:
				{
					return "ERROR GETTING LEVEL TITLE. LEVEL OUT OF RANGE. SEE PLAYER CLASS";
				}
		}
	}

	// Public function to get the player's level number [0 - 4]
	public int GetExperienceLevelNumber()
	{
		return PlayerPrefs.GetInt("ExpLevel");
	}

	// Public function to get the minimum amount of experience for a level
	// This is used for experience-related progress bars
	public int GetExperienceToNextLevel()
    {
		int levelNum = PlayerPrefs.GetInt("ExpLevel");
		int currentExp = Experience;

		switch (levelNum)
		{
			case 0:
				{
					// Level 0: Undergrad
					//  [0, 1,000) exp
					return 1000 - currentExp;
				}
			case 1:
				{
					// Level 1: MedStudent
					//  [1,000, 3,000) exp
					return 3000 - currentExp;
				}
			case 2:
				{
					// Level 2: ResidencyPhysician
					//  [3,000, 7,500) exp
					return 7500 - currentExp;
				}
			case 3:
				{
					// Level 3: Physician
					//  [7,500, 10,000) exp
					return 10000 - currentExp;
				}
			case 4:
				{
					// Level 4 (max level): ExpertSpecialist
					//  10,000+ exp
					return 0;
				}
			default:
				{
					return -1;
				}
		}
	}

	#endregion




	//private BlockStats get_blockstats()
	//{
	//	//replace X with our api url
	//	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("X?id={0}", blockId));
	//	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
	//	StreamReader reader = new StreamReader(response.GetResponseStream());
	//	string jsonResponse = reader.ReadToEnd();
	//	BlockStats info = JsonUtility.FromJson<BlockStats>(jsonResponse);
	//	return info;
	//}

}

[System.Serializable]
public class BlockStats
{
	public int COPD;
	public int COPDCorrect;
	public int CHF;
	public int CHFCorrect;
	public int Pneumonia;
	public int PneumoniaCorrect;

}