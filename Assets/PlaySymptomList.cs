using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySymptomList : MonoBehaviour
{
    #region EventHandlers

    // Function to return to main page play loop
    public void BackButtonhandler()
    {
        SceneManager.LoadScene("PlayMain");
    }

    
    // Funciton to view data for selected symptom to investigate
    public void SelectedSymptomButtonHandler()
    {
        SceneManager.LoadScene("PlaySymptomData");
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
