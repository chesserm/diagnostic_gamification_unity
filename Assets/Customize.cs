using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization; 

public class Customize : MonoBehaviour
{
    public ShopItemHandler handler;
    public List<bool> headoptions;
    public List<bool> legoptions;
    public List<bool> faceoptions;
    public List<bool> bodyoptions;

    public GameObject robotprefab;
    
    
    public void ReturnToMainMenu()
    {
        Debug.Log("leaving safely");
        
        SceneManager.LoadScene("MainMenu");
    }


    // Start is called before the first frame update
    void Start()
    {
        // Load in handler from playerprefs
        string strHandler = PlayerPrefs.GetString("ShopItemHandler");
        handler = JsonUtility.FromJson<ShopItemHandler>(strHandler);
        
        headoptions = new List<bool>(new bool[] { handler.Head01, handler.Head02 });
        legoptions = new List<bool>(new bool[] { handler.Legs01, handler.Legs02, handler.Legs03, handler.Legs04, handler.Legs05});
        faceoptions = new List<bool>(new bool[] { handler.Face01, handler.Face02, handler.Face03, handler.Face04, handler.Face05 });
        bodyoptions = new List<bool>(new bool[] { handler.Body01, handler.Body02, handler.Body03, handler.Body04, handler.Body05, handler.Body06, handler.Body07, handler.Body08 });

    }

    void OnDestroy()
    {
        // Save handler in playerprefs
        string strHandler = JsonUtility.ToJson(handler);
        PlayerPrefs.SetString("ShopItemHandler", strHandler);
    }

    //SELECTOR 
    //body part we are changing 
    public SpriteRenderer bodypart;
    //all the options we own for this bodypart TODO
    public List<Sprite> options;

    

    public int currentOption = 1;

    public void nextOption()
    {
        List<bool> robotoptions;
        if(bodypart.name == "head"){
            robotoptions = headoptions;
        }
        else if(bodypart.name == "leg"){
            robotoptions = legoptions;
        }
        else if(bodypart.name == "face"){
            robotoptions = faceoptions;
        }
        else{
            robotoptions = bodyoptions;
        }
        int lastOption = currentOption;
        currentOption++;
        while(currentOption != lastOption){
            if(currentOption >= options.Count){
                currentOption = 0;
            }

            if(robotoptions[currentOption]){
                break;
            }
            else{
                currentOption++;
            }
        }
        
        bodypart.sprite = options[currentOption];
        if(bodypart.name == "head"){
            handler.SetEquippedHead(currentOption + 1);
        }
        else if(bodypart.name == "leg"){
            handler.SetEquippedLegs(currentOption + 1);
        }
        else if(bodypart.name == "face"){
            handler.SetEquippedFace(currentOption + 1);
        }
        else{
            handler.SetEquippedBody(currentOption + 1);

            // Animation stuff
            EquipAnimationController(currentOption + 1);
        }
        PrefabUtility.SaveAsPrefabAsset(robotprefab, "Assets/robot.prefab");
    }

    public void previousOption()
    {
        List<bool> robotoptions;
        if(bodypart.name == "head"){
            robotoptions = headoptions;
        }
        else if(bodypart.name == "leg"){
            robotoptions = legoptions;
        }
        else if(bodypart.name == "face"){
            robotoptions = faceoptions;
        }
        else{
            robotoptions = bodyoptions;
        }
        int lastOption = currentOption;
        currentOption--;
        while(currentOption != lastOption){
            if(currentOption < 0){
                currentOption = options.Count - 1;
            }

            if(robotoptions[currentOption]){
                break;
            }
            else{
                currentOption--;
            }
        }
        
        bodypart.sprite = options[currentOption];
        if(bodypart.name == "head"){
            handler.SetEquippedHead(currentOption + 1);
        }
        else if(bodypart.name == "leg"){
            handler.SetEquippedLegs(currentOption + 1);
        }
        else if(bodypart.name == "face"){
            handler.SetEquippedFace(currentOption + 1);
        }
        else{
            handler.SetEquippedBody(currentOption + 1);

            // Animation stuff
            EquipAnimationController(currentOption + 1);
            
        }
        PrefabUtility.SaveAsPrefabAsset(robotprefab, "Assets/robot.prefab");
        Debug.Log(currentOption);
    }


    // Equip the Animation Controller 
    // Body Index is one indexed according to the body
    public void EquipAnimationController(int bodyIndex)
    {
        GameObject bodyObject = GameObject.Find("body");
        Animator anim = bodyObject.GetComponent<Animator>();

        switch (bodyIndex)
        {
            case 1:
                {

                    string path = "Animations/bodies/body01/body01_01_grey";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(path);
                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 2:
                {
                    string path = "Animations/bodies/body02/body02_01_grey";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> (path);
                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 3:
                {
                    string path = "Animations/bodies/body03/body03_00_grey";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> (path);
                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 4:
                {
                    string path = "Animations/bodies/body04/body04_00_grey";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> (path);
                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 5: 
                {
                    string path = "Animations/bodies/body05/body05_0";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> (path);

                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 6:
                {
                    string path = "Animations/bodies/body06/body06";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(path);

                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 7:
                {
                    string path = "Animations/bodies/body07/body07";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(path);

                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            case 8:
                {
                    string path = "Animations/bodies/body08/body08";
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(path);

                    //UnityEngine.Debug.Log(anim.runtimeAnimatorController);
                    break;
                }
            default:
                {
                    UnityEngine.Debug.Log("Passing in invalid index to EquipAnimationController()");
                    break;
                }
        }
    }
}
