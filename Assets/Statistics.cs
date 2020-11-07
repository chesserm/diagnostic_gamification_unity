using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    GameObject TextObject;
    Text coins_text;
    int coins;
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("NumCoins");
        TextObject = GameObject.FindGameObjectWithTag("coins_disp");
        coins_text = TextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coins_text.text = "coins: " + coins.ToString();
    }
}
