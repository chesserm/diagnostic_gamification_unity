using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
