using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlaySummary : MonoBehaviour
{
    #region ButtonHandlers

    int coins = 777;
    int exp = 5000;
    
    GameObject containerObject;
    Player player;

    // Function to return to main menu
    public void ContinueButtonHandler()
    {
        SceneManager.LoadScene("MainMenu");
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        containerObject = GameObject.FindGameObjectWithTag("ContainerObject");
        player = containerObject.GetComponent<Player>();

        

        // 'c' = COPD
        // 'p' = Pnueomonia
        // 'h' = CHF
        char casetype = 'c';
        bool correct = true;

        player.CompleteCase(coins, exp, casetype, correct);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {

        int coins = PlayerPrefs.GetInt("NumCoins");
        UnityEngine.Debug.Log(coins);

        // Reset the static player data so the next entry into 
        // the Play loop is a clean slate
        CaseInformation.ResetCaseInformation();
    }
}
