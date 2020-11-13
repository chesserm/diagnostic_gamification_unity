using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopButtons : MonoBehaviour
{
    public int cost;
    public string itemName;

    // Change with database connection
    public void bought()
    {
        if (GetComponentInParent<Shop>().coins >= cost)
        {
            GetComponentInParent<Shop>().coins -= cost;
            GetComponentInParent<Shop>().addItem(itemName);
        }
        // else popup a message that says not enough coins
    }
}
