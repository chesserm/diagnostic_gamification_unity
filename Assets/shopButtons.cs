using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopButtons : MonoBehaviour
{
    public int cost;
    public int level;
    // Not sure if this is how i should be making the player object
    Player player = new Player();
    public string itemName;
    public Text[] texts;
    public Image[] images;


    // Change with database connection
    public void bought()
    {
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
        if (GetComponentInParent<Shop>().coins >= cost && player.GetExperienceLevelNumber() >= level)
        {
            if (!GetComponentInParent<Shop>().handler.IsPurchased(itemName))
            {
                GetComponentInParent<Shop>().coins -= cost;
                GetComponentInParent<Shop>().addItem(itemName);
                texts[0].text = "OWNED";
                texts[1].enabled = false;
                images[2].enabled = false;
            }
        }
        // else popup a message that says not enough coins
    }

    void Start()
    {
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
        if (GetComponentInParent<Shop>().handler.IsPurchased(itemName))
        {
            texts[0].text = "OWNED";
            texts[1].enabled = false;
            images[2].enabled = false;
        }
        else if (player.GetExperienceLevelNumber() < level)
        {
            texts[0].text = "Requires " + player.GetTitleForItem(level);
            texts[0].fontSize = 40;
            texts[1].enabled = false;
            images[2].enabled = false;
        }
    }
}
