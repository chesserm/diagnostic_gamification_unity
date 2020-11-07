using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    int coins;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("NumCoins");
    }

    public void buy_item()
    {
        coins += 10;
        PlayerPrefs.SetInt("NumCoins", coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
