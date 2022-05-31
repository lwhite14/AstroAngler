using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodItem : MonoBehaviour
{
    public string rodName; //this is the rod's name
    public int rodPrice; //this is the rod's price 
    public Sprite rodImage; //this is the rod's image
    public int rodLevel; //this is the rod's level

   
    public string getName()
    {
        return rodName; //returns the rod's name

    }

    public int getPrice()
    {
        return rodPrice; //returns the rod's price
    }

    public Sprite getImage()
    {
        return rodImage; //returns the rod's image
    }

    public int getLevel()
    {
        return rodLevel; //returns the rod's level
    }
}
