using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopButtons : MonoBehaviour
{
    public int cost;
    public string itemName;
    public Text[] texts;


    // Change with database connection
    public void bought()
    {
        texts = GetComponentsInChildren<Text>();
        if (GetComponentInParent<Shop>().coins >= cost)
        {
            if (!GetComponentInParent<Shop>().handler.IsPurchased(itemName))
            {
                GetComponentInParent<Shop>().coins -= cost;
                GetComponentInParent<Shop>().addItem(itemName);
                texts[0].text = "OWNED";
            }
        }
        // else popup a message that says not enough coins
    }

    void Start()
    {
        texts = GetComponentsInChildren<Text>();
        if (GetComponentInParent<Shop>().handler.IsPurchased(itemName))
        {
            texts[0].text = "OWNED";
        }
    }
}
