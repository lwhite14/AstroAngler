using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    public GameObject buyingMenuPanel; //this is for the buying menu panel
    public GameObject sellingMenuPanel; //this is for the selling menu panel

    public void EnableBuyingMenu() 
    {
        //enables the buying menu and disables the selling menu
        sellingMenuPanel.SetActive(false); 
        buyingMenuPanel.SetActive(true);
    }

    public void EnableSellingMenu() 
    {
        //enable the selling menu and disables the buying menu
        buyingMenuPanel.SetActive(false);
        sellingMenuPanel.SetActive(true);
    }
}
