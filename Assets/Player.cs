using System.Collections;
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
	int NumCoins
	{
		get { return PlayerPrefs.GetInt("NumCoins"); }
	}
	int Experience
	{
		get { return PlayerPrefs.GetInt("Experience"); }
	}
	int NextCase
	{
		get { return PlayerPrefs.GetInt("NextCase"); }
	}
	int total_correct
	{
		get { return PlayerPrefs.GetInt("total_correct"); }
	}
	string ExpLevel
	{
		get { return PlayerPrefs.GetString("ExpLevel"); }
	}
	string Block
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
			PlayerPrefs.SetInt("NextCase", 0);
			PlayerPrefs.SetInt("total_correct", 0);
			PlayerPrefs.SetString("ExpLevel", "undergrad");
			BlockStats firstBlock = new BlockStats();
			PlayerPrefs.SetString("CurrentBlock", JsonUtility.ToJson(firstBlock));
		}
	}

	public void CompleteCase(int coins, int xp, char casetype, bool correct)
    {
		PlayerPrefs.SetInt("NumCoins", this.NumCoins + coins);
		PlayerPrefs.SetInt("Experience", this.Experience + xp);
		PlayerPrefs.SetInt("NextCase", this.NextCase + 1);

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

	public void callplayercomplete()
	{
		this.CompleteCase(10, 10, 'c', true);
	}

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