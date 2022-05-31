using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitItem : MonoBehaviour
{
    public string baitName; //this is the bait name
    public int baitPrice; //this is the bait price
    public Sprite baitImage; //this is the bait image
    public int baitLevel; //this is the bait level

    
    public string getName()
    {
        return baitName; //returns the bait name

    }

    public int getPrice()
    {
        return baitPrice; //returns the bait's price
    }

    public Sprite getImage()
    {
        return baitImage; //returns the bait image
    }

    public int getLevel()
    {
        return baitLevel; //returns the bait's level
    }
}
