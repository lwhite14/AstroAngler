using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishItem : MonoBehaviour
{
    private int fishValue; //this is for the number that are currently caught
    public int fishPrice; //the price the fish will sell for
    private FishManager manager; //a reference to the fishmanager script
    private FishInventory inventory; //a reference to the fishinventory script 

   
    private void Start()
    {
        manager = FindObjectOfType<FishManager>(); //gets the component with the fishmanager script
        inventory = FindObjectOfType<FishInventory>(); //gets the component with the inventory script 
    }

    public int GetValue()
    {
        return fishValue; //returns the fish value
    }

    public int GetPrice()
    {
        return fishPrice; //returns the fish price
    }

    public void SetValue(int inValue)
    {
        fishValue = inValue; //sets the value by the inValue parameter
    }

    
    public void Collect()
    {
        if (inventory.isFull != true) //if the inventory is not full
        {
            manager.AddValue(); //call this function
            gameObject.SetActive(false); //disable visibility of the fish object 
        }
    }
}
