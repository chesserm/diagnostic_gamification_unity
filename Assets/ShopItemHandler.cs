using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


[System.Serializable]
public class ShopItemHandler
{
    public bool Head01;
    public bool Head02;
    public bool Body01;
    public bool Body02;
    public bool Body03;
    public bool Body04;
    public bool Body05;
    public bool Legs01;
    public bool Legs02;
    public bool Legs03;
    public bool Legs04;
    public bool Legs05;
    public bool Face01;
    public bool Face02;
    public bool Face03;
    public bool Face04;
    public bool Face05;
    public bool BodyGrey;
    public bool BodyBronze;
    public bool BodySilver;
    public bool BodyGold;
    public bool BodyPlatinum;
    private int EquippedHead;
    private int EquippedBody;
    private int EquippedLegs;
    private int EquippedFace;
    private int EquippedColor;

    public void PurchaseItem(string itemName)
    {
        if (itemName == "Head01")
        {
            Head01 = true;
        }
        else if (itemName == "Head02")
        {
            Head02 = true;
        }
        else if (itemName == "Body01")
        {
            Body01 = true;
        }
        else if (itemName == "Body02")
        {
            Body02 = true;
        }
        else if (itemName == "Body03")
        {
            Body03 = true;
        }
        else if (itemName == "Body04")
        {
            Body04 = true;
        }
        else if (itemName == "Body05")
        {
            Body05 = true;
        }
        else if (itemName == "Legs01")
        {
            Legs01 = true;
        }
        else if (itemName == "Legs02")
        {
            Legs02 = true;
        }
        else if (itemName == "Legs03")
        {
            Legs03 = true;
        }
        else if (itemName == "Legs04")
        {
            Legs04 = true;
        }
        else if (itemName == "Legs05")
        {
            Legs05 = true;
        }
        else if (itemName == "Face01")
        {
            Face01 = true;
        }
        else if (itemName == "Face02")
        {
            Face02 = true;
        }
        else if (itemName == "Face03")
        {
            Face03 = true;
        }
        else if (itemName == "Face04")
        {
            Face04 = true;
        }
        else if (itemName == "Face05")
        {
            Face05 = true;
        }
        else if (itemName == "BodyGrey")
        {
            BodyGrey = true;
        }
        else if (itemName == "BodyBronze")
        {
            BodyBronze = true;
        }
        else if (itemName == "BodySilver")
        {
            BodySilver = true;
        }
        else if (itemName == "BodyGold")
        {
            BodyGold = true;
        }
        else if (itemName == "BodyPlatinum")
        {
            BodyPlatinum = true;
        }
    }

    public void SetEquippedHead(int headNum)
    {
        EquippedHead = headNum;
    }

    public void SetEquippedBody(int bodyNum)
    {
        EquippedBody = bodyNum;
    }

    public void SetEquippedLegs(int legsNum)
    {
        EquippedLegs = legsNum;
    }
    public void SetEquippedFace(int faceNum)
    {
        EquippedFace = faceNum;
    }
    public void SetEquippedColor(string color)
    {
        color = color.ToLower();
        if (color == "grey")
        {
            EquippedColor = 1;
        }
        else if (color == "bronze")
        {
            EquippedColor = 2;
        }
        else if (color == "silver")
        {
            EquippedColor = 3;
        }
        else if (color == "gold")
        {
            EquippedColor = 4;
        }
        else if (color == "platinum")
        {
            EquippedColor = 5;
        }
    }
}
