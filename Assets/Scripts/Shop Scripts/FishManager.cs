using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishManager : MonoBehaviour
{
    public int value = -1; //holds the current amount of fish

    private FishItem fish; //this is for the fish object
    public Text valueText; //this is for when the fish gets updated and for showing the amount onscreen

    public FishInventory inventory; //a reference for our fish inventory 

    private void Start()
    {
        fish = FindObjectOfType<FishItem>(); //gets the fish object
    }

    public void AddValue()
    {
        
        inventory.AddToArray(fish); //adds the fish to the array (calls the function)
        if (!inventory.isFull)
        {
            value++; //increments the value
            Debug.Log(value); //displays the value to the console
            fish.SetValue(value); //sets the fish value
            valueText.text = fish.GetValue().ToString(); //shows the fish value onscreen
        }
         
        
    }

    public void SubtractValue(int subValue)
    {
        value = value - subValue; //subtracts the value by the subvalue parameter
        Debug.Log(value); //displays the value to the console
        fish.SetValue(value); //sets the fish value
        valueText.text = fish.GetValue().ToString();  //shows the fish value onscreen
    }
}
