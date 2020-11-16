using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Don't change this, it's needed for UI skin
    //#region CustomUISkin
    //public GUISkin customSkin;

    //void OnGUI()
    //{
    //    GUI.skin = customSkin;
    //}

    //#endregion


    public ShopItemHandler handler;

    // Go to Play Scene
    public void GoToPlay()
    {
        SceneManager.LoadScene("Play");
    }

    // Go to Shop Scene
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    // Go to Customize Scene
    public void GoToCustomize()
    {
        SceneManager.LoadScene("Customize");
    }

    // Go to Statistics Scene
    public void GoToStatistics()
    {
        SceneManager.LoadScene("Statistics");
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("ShopItemHandler"))
        {
            handler = new ShopItemHandler();
            handler.Head01 = true;
            handler.Body01 = true;
            handler.Face01 = true;
            handler.BodyGrey = true;
            handler.Legs01 = true;
            handler.SetEquippedHead(1);
            handler.SetEquippedBody(1);
            handler.SetEquippedLegs(1);
            handler.SetEquippedFace(1);
            handler.SetEquippedColor("grey");

            // Save handler in playerprefs
            string strHandler = JsonUtility.ToJson(handler);
            PlayerPrefs.SetString("ShopItemHandler", strHandler);
        }
    }
}
