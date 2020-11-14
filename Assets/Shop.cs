using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization;

public class Shop : MonoBehaviour
{
    // Get coins from database
    public int coins;
    public Text coinsText;
    public ShopItemHandler handler;

    public void addItem(string item)
    {
        // Add item to playerprefs list if we can have one
        coinsText.text = coins.ToString();
        handler.PurchaseItem(item);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load in handler from playerprefs
        string strHandler = PlayerPrefs.GetString("ShopItemHandler");
        handler = JsonUtility.FromJson<ShopItemHandler>(strHandler);
       
        
        // Load in coin amount from playerprefs
        if (PlayerPrefs.HasKey("NumCoins"))
        {
            coins = PlayerPrefs.GetInt("NumCoins");
        }
        else
        {
            coins = 1000;

        }
        coinsText.text = coins.ToString();
        Debug.Log(coins);
    }

    void OnDestroy()
    {
        // Save coins in playerprefs
        PlayerPrefs.SetInt("NumCoins", coins);

        // Save handler in playerprefs
        string strHandler = JsonUtility.ToJson(handler);
        PlayerPrefs.SetString("ShopItemHandler", strHandler);
    }
}
