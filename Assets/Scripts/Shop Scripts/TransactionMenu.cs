using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionMenu : MonoBehaviour
{

    public Text itemNameText; //this is for item name text

    public Image productImage; //this is for the product image 

    public Image[] stars; //holds the five star rating system

    public Sprite goldStar; //this is the gold star which represents the level
    public Sprite blackStar; //this is the black star which fills in the images that are greater than the level

    public Text buyItemPrompt; //this is for the buy item prompt

    public GameObject menuPanel; //this is for setting the panel active and unactive

    public BuyingMenu buyingMenu; //a reference for the buying menu 

    public Currency currencyManager; //a reference for the currency manager

    private int productIndex; //this is for current element of the array
    
    //these arrays are used for the buy function 
    private Hook[] hookArray; 
    private Rods[] rodArray;
    private Bait[] baitArray;
    private Reel[] reelArray;

    //used for enabling and disabling the acceptButton
    public Button acceptButton;

    //used for interacting with the players inventory
    public PlayerInventory playerInventory;

  
    public void DisplayHookData(Hook[] hooks, int index)
    {
        //gets the image and name of the product
        itemNameText.text = hooks[index].hookName;
        productImage.sprite = hooks[index].gameObject.GetComponent<InventoryItemHolder>().invIcon.GetComponent<Image>().sprite;

        //displays the number of stars based on the player's level (if level is at 2, it will display two stars)

        for (int i = 0; i < hooks[index].level; i++)
        {
            if (i < hooks[index].level)
            {
                stars[i].sprite = goldStar;
            }
        }

        //the hook's level goes into this level variable

        int level = hooks[index].level;

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)

        for(int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + hooks[index].price + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        hookArray = hooks;
    }

    public void DisplayRodData(Rods[] rods, int index)
    {
        //gets the image and name of the product
        itemNameText.text = rods[index].rodName;
        productImage.sprite = rods[index].gameObject.GetComponent<InventoryItemHolder>().invIcon.GetComponent<Image>().sprite;

        //displays the number of stars based on the product's level (if level is at 2, it will display two stars)
        for (int i = 0; i < rods[index].level; i++)
        {
            if (i < rods[index].level)
            {
                stars[i].sprite = goldStar;
            }
        }

        //the rod's level goes into this level variable
        int level = rods[index].level;

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)

        for (int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + rods[index].price + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        rodArray = rods;
    }

    public void DisplayBaitData(Bait[] baits, int index)
    {
        //gets the image and name of the product
        itemNameText.text = baits[index].baitName;
        productImage.sprite = baits[index].gameObject.GetComponent<InventoryItemHolder>().invIcon.GetComponent<Image>().sprite;

        //displays the number of stars based on the product's level (if level is at 2, it will display two stars)
        for (int i = 0; i < baits[index].level; i++)
        {
            if (i < baits[index].level)
            {
                stars[i].sprite = goldStar;
            }
        }

        //the bait's level goes into this level variable
        int level = baits[index].level;

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)
        for (int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + baits[index].price + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        baitArray = baits;
    }

    public void DisplayReelData(Reel[] reels, int index)
    {
        //gets the image and name of the product
        itemNameText.text = reels[index].reelName;
        productImage.sprite = reels[index].gameObject.GetComponent<InventoryItemHolder>().invIcon.GetComponent<Image>().sprite;

        //displays the number of stars based on the player's level (if level is at 2, it will display two stars)

        for (int i = 0; i < reels[index].level; i++)
        {
            if (i < reels[index].level)
            {
                stars[i].sprite = goldStar;
            }
        }

        //the hook's level goes into this level variable

        int level = reels[index].level;

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)

        for (int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + reels[index].price + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        reelArray = reels;
    }


    public void Decline()
    {
        menuPanel.SetActive(false); //disables this menu
        buyingMenu.buyingMenuPanel.SetActive(true); //enables the buying menu
        acceptButton.enabled = true; //enables the accept button
    }

    public void Buy()
    {
        if (BuyingMenu.isHook) //if the product is a hook
        {
            //Debug.Log(productIndex);
            //Debug.Log(currencyManager.currency);
            //int cost = hookArray[productIndex].getPrice();
            //Debug.Log(cost);

            //if the currency is greatyr than the product price
            if (currencyManager.GetCurrency() >= hookArray[productIndex].price)
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(hookArray[productIndex].price); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// HOOK
                playerInventory.AddHook(hookArray[productIndex].gameObject);

            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }

        if (BuyingMenu.isRod) //if the product is a rod
        {
            //int cost = rodArray[productIndex].getPrice();
            // Debug.Log(cost);

            //if the currency is greatyr than the product price
            if (currencyManager.GetCurrency() >= rodArray[productIndex].price)
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(rodArray[productIndex].price); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// ROD
                playerInventory.AddRod(rodArray[productIndex].gameObject);


            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }
        else if (BuyingMenu.isBait) //if the product is a bait
        {
            //int cost = baitArray[productIndex].getPrice();
            //Debug.Log(cost);

            //if the currency is greatyr than the product price
            if (currencyManager.GetCurrency() >= baitArray[productIndex].price)
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(baitArray[productIndex].price); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// BAIT
                playerInventory.AddBait(baitArray[productIndex].gameObject);

            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }
        else if (BuyingMenu.isReel)
        {
            if (currencyManager.GetCurrency() >= reelArray[productIndex].price)
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(reelArray[productIndex].price); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// BAIT
                playerInventory.AddReel(reelArray[productIndex].gameObject);

            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }



        
    }


}
