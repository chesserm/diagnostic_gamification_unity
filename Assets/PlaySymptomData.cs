using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySymptomData : MonoBehaviour
{
    #region EventHandlers

    // Function to Continue to Reasoning Page
    public void ContinueButtonHandler()
    {
        SceneManager.LoadScene("PlayReasoning");
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
