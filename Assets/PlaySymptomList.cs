using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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




    // Start is called before the first frame update
    void Start()
    {
        // Just an extra safeguard to make sure this is properly reset
        // This variable should only be set during this scene and is then critical
        // for the following data and reasoning pages/scenes
        CaseInformation.SelectedSymptom = SymptomState.Nothing;
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
