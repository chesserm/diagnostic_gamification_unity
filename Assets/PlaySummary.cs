using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySummary : MonoBehaviour
{
    #region ButtonHandlers

    // Function to return to main menu
    public void ContinueButtonHandler()
    {
        SceneManager.LoadScene("MainMenu");
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
