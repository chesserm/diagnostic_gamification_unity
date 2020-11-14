using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;

public class Customize : MonoBehaviour
{
    public ShopItemHandler handler;
    public List<bool> headoptions;
    public List<bool> legoptions;
    public List<bool> faceoptions;
    public List<bool> bodyoptions;
    
    
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // Start is called before the first frame update
    void Start()
    {
        // Load in handler from playerprefs
        if (PlayerPrefs.HasKey("ShopItemHandler"))
        {
            string strHandler = PlayerPrefs.GetString("ShopItemHandler");
            handler = JsonUtility.FromJson<ShopItemHandler>(strHandler);
        }
        else
        {
            handler = new ShopItemHandler();
            handler.Head01 = true;
            handler.Body01 = true;
            handler.Face01 = true;
            handler.BodyGrey = true;
            handler.Legs01 = true;
            handler.SetEquippedHead(1);
            handler.SetEquippedBody(1);
            handler.SetEquippedLegs(1);
            handler.SetEquippedFace(1);
            handler.SetEquippedColor("grey");

        }

        headoptions = new List<bool>(new bool[] { handler.Head01, handler.Head02 });
        legoptions = new List<bool>(new bool[] { handler.Legs01, handler.Legs02, handler.Legs03, handler.Legs04, handler.Legs05});
        faceoptions = new List<bool>(new bool[] { handler.Face01, handler.Face02, handler.Face03, handler.Face04, handler.Face05 });
        bodyoptions = new List<bool>(new bool[] { handler.Body01, handler.Body02, handler.Body03, handler.Body04, handler.Body05 });

    }

    // Update is called once per frame
    void Update()
    {

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
        }
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
            if(currentOption <= 0){
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
        }

    }
}
