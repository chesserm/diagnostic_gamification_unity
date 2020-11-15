using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using HelperNamespace;

public class PlayMain : MonoBehaviour
{

    // Lists to hold sprites to randomly pull from
    public List<Sprite> bodies;
    public List<Sprite> faces;
    public List<Sprite> maleHairs;
    public List<Sprite> femaleHairs;
    public List<Sprite> maleKits;
    public List<Sprite> femaleKits;

    // Prefab GameObject
    public GameObject avatarPrefab;




    #region ButtonHandlers



    // Function to return to main menu
    public void ReturnToMainMenu()
    {
        // Reset the static class's data so a new case can be fetched on the next entry
        CaseInformation.ResetCaseInformation();

        // Return Player to Main Menu
        SceneManager.LoadScene("MainMenu");
    }


    // Function to go to Diagnose page
    public void DiagnoseButtonHandler()
    {
        SceneManager.LoadScene("PlayDiagnose");
    }


    // Function to go to Investigate page
    public void InvestigateButtonHandler()
    {
        SceneManager.LoadScene("PlaySymptomList");
    }

    #endregion 



    // Function to randomly set the image of the patient avatar
    private void RandomlyCreatePatientAvatar()
    {
        // Get objects and components
        GameObject hairObject = GameObject.Find("Hair");
        SpriteRenderer hairSprite = hairObject.GetComponent<SpriteRenderer>();

        GameObject bodyObject = GameObject.Find("Body");
        SpriteRenderer bodySprite = bodyObject.GetComponent<SpriteRenderer>();

        GameObject faceObject = GameObject.Find("Face");
        SpriteRenderer faceSprite = faceObject.GetComponent<SpriteRenderer>();

        GameObject kitObject = GameObject.Find("Kit");
        SpriteRenderer kitSprite = kitObject.GetComponent<SpriteRenderer>();


        



        // Generate indices for determining patient avatar
        System.Random rnd = new System.Random();
        
        int faceIndex = rnd.Next(0, 3);
        int hairIndex = rnd.Next(0, 3);
        int bodyIndex = rnd.Next(0, 3);
        int kitIndex = rnd.Next(0, 3);

        faceSprite.sprite = faces[faceIndex];
        bodySprite.sprite = bodies[bodyIndex];

        // Use same gender as case information
        if (CaseInformation.patient.Gender.ToLower() == "female")
        {
            hairSprite.sprite = femaleHairs[hairIndex];
            kitSprite.sprite = femaleKits[kitIndex];
        }
        else
        {
            hairSprite.sprite = maleHairs[hairIndex];
            kitSprite.sprite = maleKits[kitIndex];
        }

        // Save prefab
        PrefabUtility.SaveAsPrefabAsset(avatarPrefab, "Assets/PatientAvatar.prefab");
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Check to see if it is the first visit to the MainPlay page
        // so we know to generate the random avatar for this play session
        if (CaseInformation.isFirstPlayMainVisit)
        {
            CaseInformation.isFirstPlayMainVisit = false;
            RandomlyCreatePatientAvatar();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
