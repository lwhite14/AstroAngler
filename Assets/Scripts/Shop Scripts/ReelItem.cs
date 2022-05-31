using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelItem : MonoBehaviour
{
    public string reelname; //this is the reel's name
    public int reelPrice; //this is the reel's price
    public Sprite reelImage; //this is the reel's image
    public int reelLevel; //this is the reel's level


    public string getName()
    {
        return reelname; //returns the reel's name

    }

    public int getPrice()
    {
        return reelPrice; //returns the reel's price 
    }

    public Sprite getImage()
    {
        return reelImage; //returns the reel's image
    }

    public int getLevel()
    {
        return reelLevel; //returns the reel's level
    }
}
