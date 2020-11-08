using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayReasoning : MonoBehaviour
{

    #region EventHandlers

    // Function to continue to Main Play Page after reasoning is selected
    public void ReasoningButtonHandler()
    {
        SceneManager.LoadScene("PlayMain");
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
