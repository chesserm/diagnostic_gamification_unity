using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HelperNamespace;

public class PlaySymptomList : MonoBehaviour
{
    #region EventHandlers

    // Function to return to main page play loop
    public void BackButtonhandler()
    {
        SceneManager.LoadScene("PlayMain");
    }

    // Function to change secnes and view data for selected symptom to investigate
    public void SelectedSymptomButtonHandler()
    {
        SceneManager.LoadScene("PlaySymptomData");
    }



    // Function corresponding to selecting the General Exam
    public void SelectGeneralSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.General;
    }

    // Function corresponding to selecting the Head Exam
    public void SelectHeadSymptom()
    {
        // Set global flag to know if the user has investigated the head symptom yet.
        CaseInformation.hasViewedHeadExam = true;

        CaseInformation.SelectedSymptom = SymptomState.Head;

    }

    // Function corresponding to selecting the Neck Exam
    public void SelectNeckSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Neck;
    }

    // Function corresponding to selecting the Heart Exam
    public void SelectHeartSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Heart;
    }

    // Function corresponding to selecting the Lung Exam
    public void SelectLungSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Lungs;
    }

    // Function corresponding to selecting the Extremities Exam
    public void SelectExtremitiesSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Extremities;
    }

    // Function corresponding to selecting the Extremities Exam
    public void SelectAbdomenSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Abdomen;
    }

    // Function corresponding to selecting the Skin Exam
    public void SelectSkinSymptom()
    {
        // Set global flag to know if the user has investigated the skin symptom yet.
        CaseInformation.hasViewedSkinExam = true;
        CaseInformation.SelectedSymptom = SymptomState.Skin;
    }

    // Function corresponding to selecting the Oxygen Investigation Option
    public void SelectOxygenSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Oxygen;
    }

    // Function corresponding to requesting the Bloodwork
    public void SelectBloodSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Bloodwork;
    }

    // Function corresponding to requesting the x-ray imaging
    public void SelectImagingSymptom()
    {
        CaseInformation.SelectedSymptom = SymptomState.Imaging;
    }

    #endregion 



    // Helper function called in Start() to grey out the text of the buttons
    // corresponding to symptoms that have already been investigated
    private void CheckViewedSymptoms()
    {
        // Source: https://stackoverflow.com/questions/46962565/how-to-convert-hex-to-colorrgba-with-tryparsehtmlstring
        string greyHTMLColor = "#797979";
        Color newColor;
        ColorUtility.TryParseHtmlString(greyHTMLColor, out newColor);

        // Get the button component for each symptom investigated and set it's text color to Grey
        GameObject button = GameObject.Find("GeneralButton");

        foreach (var symptom in CaseInformation.UserReasoning.Keys)
        {
            switch (symptom)
            {
                case (SymptomState.General):
                    {
                        button = GameObject.Find("GeneralButton");
                        break;
                    }
                case (SymptomState.Neck):
                    {
                        button = GameObject.Find("NeckButton");
                        break;
                    }
                case (SymptomState.Heart):
                    {
                        button = GameObject.Find("HeartButton");
                        break;
                    }
                case (SymptomState.Lungs):
                    {
                        button = GameObject.Find("LungButton");
                        break;
                    }
                case (SymptomState.Extremities):
                    {
                        button = GameObject.Find("ExtremitiesButton");
                        break;
                    }
                case (SymptomState.Abdomen):
                    {
                        button = GameObject.Find("AbdomenButton");
                        break;
                    }
                case (SymptomState.Oxygen):
                    {
                        button = GameObject.Find("OxygenButton");
                        break;
                    }
                case (SymptomState.Imaging):
                    {
                        button = GameObject.Find("ImagingButton");
                        break;
                    }
                case (SymptomState.Bloodwork):
                    {
                        button = GameObject.Find("BloodButton");
                        break;
                    }
                case (SymptomState.Nothing):
                    {
                        UnityEngine.Debug.Log("ERROR: CurrentSymptom not found in ChecKViewedSymptom()");
                        break;
                    }
                default:
                    {
                        UnityEngine.Debug.Log("ERROR: Hit default case of switch-case in ChecKViewedSymptom()");
                        break;
                    }
            } //switch

            // Change color of text component of "Text" child gameobject 
            // source: https://forum.unity.com/threads/change-button-text.424817/
            button.GetComponentInChildren<Text>().color = newColor;
            
        } //foreach

        // Check if the head exam symptom has been investigated using its boolean flag
        if (CaseInformation.hasViewedHeadExam)
        {
            button = GameObject.Find("HeadButton");
            button.GetComponentInChildren<Text>().color = newColor;
        }

        // Check if the skin exam symptom has been investigated using its boolean flag
        if (CaseInformation.hasViewedSkinExam)
        {
            button = GameObject.Find("SkinButton");
            button.GetComponentInChildren<Text>().color = newColor;
        }

    } //function



    // Start is called before the first frame update
    void Start()
    {
        // Just an extra safeguard to make sure this is properly reset
        // This variable should only be set during this scene and is then critical
        // for the following data and reasoning pages/scenes
        CaseInformation.SelectedSymptom = SymptomState.Nothing;

        // Go though each investigated symptom and change the button text from white to grey
        CheckViewedSymptoms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        UnityEngine.Debug.Log(CaseInformation.SelectedSymptom);
    }
}
