using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookItem : MonoBehaviour
{
    public string hookname; //this is the hook's name
    public int hookPrice; //this is the hook's price
    public Sprite hookImage; //this is the hook's image
    public int hookLevel; //this is the hook's level


    public string getName()
    {
        return hookname; //returns the hook's name

    }

    public int getPrice()
    {
        return hookPrice; //returns the hook's price 
    }

    public Sprite getImage()
    {
        return hookImage; //returns the hook's image
    }

    public int getLevel()
    { 
        return hookLevel; //returns the hook's level
    }
}
