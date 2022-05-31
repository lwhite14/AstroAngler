using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInventory : MonoBehaviour
{
    public FishItem[] fishes; //a collection of fishes currently caught
    public int index; //gets the current element of the array

    public bool isFull; //checks if the inventory is full


    
    public void AddToArray(FishItem fishElement) //fishelement is the object going to be added to the array
    {
        if(index != fishes.Length) //if index is not equal to the length of the array
        {
            fishes[index] = fishElement; //add the object to the array
            index++; //add the index
        }
        else
        {
            isFull = true; //set isfull to true
            Debug.Log("You cannot hold anymore fish"); //displays this message in the console 
        }
    }
}
