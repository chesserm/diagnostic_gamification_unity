using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization;

public class Shop : MonoBehaviour
{
    // Get coins from database
    public int coins = 1000;
    public Text coinsText;
    public ShopItemHandler handler;

    public void addItem(string item)
    {
        // Add item to playerprefs list if we can have one
        coinsText.text = coins.ToString();
        //handler.PurchaseItem()
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load in handler from playerprefs
        if (PlayerPrefs.HasKey("ShopItemHandler"))
        {
            string strHandler = PlayerPrefs.GetString("ShopItemHandler");
            handler = JsonUtility.FromJson<ShopItemHandler>(strHandler);
        }
        else
        {
            handler = new ShopItemHandler();
            handler.Head01 = true;
            handler.Body01 = true;
            handler.Face01 = true;
            handler.BodyGrey = true;
            handler.Legs01 = true;
            //TODO: Set the equipped default values
        }
        // Load in coin amount from playerprefs
        if (PlayerPrefs.HasKey("NumCoins"))
        {
            coins = PlayerPrefs.GetInt("NumCoins");
            coins = 99999;
        }
        else
        {
            coins = 99999;

        }
        Debug.Log(coins);
    }

    // Update is called once per frame
    void Update()
    {
        
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
