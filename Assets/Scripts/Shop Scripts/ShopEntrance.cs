using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    public GameObject sellingMenu; //this is for the selling menu 
   // public GameObject shopEntranceButton; //a button for opening the shop
    //public GameObject addFishButton; //test button for adding fish (not needed)
    public GameObject buyMenu; //this for the buying menu 

    public GameObject fishAndCurrencyUI;


    public void EnterStore()
    {
        buyMenu.SetActive(true); //enables visibility of shop UI
        fishAndCurrencyUI.SetActive(true);
        //shopEntranceButton.SetActive(false); //disables visibility of shop entrance button
        //addFishButton.SetActive(false); //disables visibility of the add fish button
    }

    public void ExitStore()
    {
        //sellingMenu.SetActive(false); //disables visibility of the selling menu 
        buyMenu.SetActive(false); //disables visibility of buying menu 
        fishAndCurrencyUI.SetActive(false);
        //shopEntranceButton.SetActive(true); //enables visibility of shop entrance button
        //addFishButton.SetActive(true); //enables visibility of the add fish button
    }
}
