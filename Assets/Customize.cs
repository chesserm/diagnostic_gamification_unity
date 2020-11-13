using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;

public class Customize : MonoBehaviour
{
    public ShopItemHandler handler;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
