using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using Assets;

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
	int NextCase;
	{
		get { return PlayerPrefs.GetInt("NextCase"); }
	}
	int total_correct
	{
		get { return PlayerPrefs.GetInt("total_correct"); }
	}
	string ExpLevel
	{
		get { return PlayerPrefs.GetInt("ExpLevel"); }
	}

// Start is called before the first frame update
void Start()
    {
		// if player prefs hasnt been populated initialize the values
		if(!playerPref.HasKey("NumCoins"))
        {
			PlayerPrefs.SetInt("NumCoins", 0);
			PlayerPrefs.SetInt("Experience", 0);
			PlayerPrefs.SetInt("NextCase", 0);
			PlayerPrefs.SetInt("total_correct", 0);
			PlayerPrefs.SetString("ExpLevel", undergrad);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void CompleteCase(int coins, int xp)
    {
		PlayerPrefs.SetInt("NumCoins", NumCoins + coins);
		PlayerPrefs.SetInt("Experience", Experience + xp);
		PlayerPrefs.SetInt("NextCase", NextCase + 1);
	}

	private BlockStats get_blockstats()
	{
		//replace X with our api url
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("X?id={0}", blockId));
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		StreamReader reader = new StreamReader(response.GetResponseStream());
		string jsonResponse = reader.ReadToEnd();
		BlockStats info = JsonUtility.FromJson<BlockStats>(jsonResponse);
		return info;
	}

}

[serializable]
public class BlockStats
{
	public int startingIndex { get; set; }
	public int COPD { get; set; }
	public int COPDCorrect { get; set; }
	public int CHF { get; set; }
	public int CHFCorrect { get; set; }
	public int Pneumonia { get; set; }
	public int PneumoniaCorrect { get; set; }
}