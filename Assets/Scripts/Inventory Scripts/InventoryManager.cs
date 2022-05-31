using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Currency currencyManager;

    [Header("Needed Gameobjects")]
    public GameObject itemUI;
    public GameObject noItemIcon;
    public GameObject selectedUI;

    [Header("Grid Layouts")]
    public GameObject[] gridLayouts = new GameObject[5];

    GameObject selectedRod;
    GameObject selectedBait;
    GameObject selectedHook;
    GameObject selectedReel;
    GameObject[,] itemUis = new GameObject[5, 9];


    private void Start()
    { 
        GameObject[] tempInventory;

        for (int i = 0; i < itemUis.GetLength(0); i++)
        {
            if (i == 0)
            {
                tempInventory = playerInventory.inventory.GetRods();
            }
            else if (i == 1) 
            { 
                tempInventory = playerInventory.inventory.GetBait(); 
            }
            else if (i == 2) 
            { 
                tempInventory = playerInventory.inventory.GetHooks(); 
            }
            else if (i == 3)
            {
                tempInventory = playerInventory.inventory.GetReels();
            }
            else 
            { 
                tempInventory = playerInventory.inventory.GetFish(); 
            }
            for (int j = 0; j < itemUis.GetLength(1); j++)
            {
                itemUis[i, j] = Instantiate(itemUI) as GameObject;
                itemUis[i, j].transform.parent = gridLayouts[i].transform;
                if (tempInventory[j] == null)
                {
                    itemUis[i, j].GetComponent<ItemUI>().currentItem = noItemIcon;
                    itemUis[i, j].GetComponent<ItemUI>().Draw(true, i, j);
                }
                else
                {
                    itemUis[i, j].GetComponent<ItemUI>().currentItem = tempInventory[j]; //.GetComponent<Hook>().invIcon;
                    itemUis[i, j].GetComponent<ItemUI>().Draw(false, i, j);
                }
            }
        }
        this.ChangeSelectedRod(itemUis[0, 0].GetComponent<ItemUI>().currentItem);
        this.ChangeSelectedBait(itemUis[1, 0].GetComponent<ItemUI>().currentItem);
        this.ChangeSelectedHook(itemUis[2, 0].GetComponent<ItemUI>().currentItem);
        this.ChangeSelectedReel(itemUis[3, 0].GetComponent<ItemUI>().currentItem);

    }

    public void ChangeSelectedRod(GameObject newSelected)
    {
        Destroy(selectedRod);
        playerInventory.rodSelected = newSelected;
        selectedRod = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedRod.transform) as GameObject;
        selectedRod.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedRod.transform;
    }

    public void ChangeSelectedBait(GameObject newSelected)
    {
        Destroy(selectedBait);
        playerInventory.baitSelected = newSelected;
        selectedBait = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedBait.transform) as GameObject;
        selectedBait.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedBait.transform;
    }

    public void ChangeSelectedHook(GameObject newSelected)
    {
        Destroy(selectedHook);
        playerInventory.hookSelected = newSelected;
        selectedHook = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedHook.transform) as GameObject;
        selectedHook.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedHook.transform;
    }

    public void ChangeSelectedReel(GameObject newSelected)
    {
        Destroy(selectedReel);
        playerInventory.reelSelected = newSelected;
        selectedReel = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedReel.transform) as GameObject;
        selectedReel.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedReel.transform;
    }

    public void SellFish(int inputIndex) 
    {
        playerInventory.SellFish(inputIndex);
        AddFish();
    }

    public void AddFish()
    {
        GameObject[] tempInventory = playerInventory.inventory.GetFish();
        for (int i = 0; i < itemUis.GetLength(1); i++)
        {
            if (tempInventory[i] != null)
            {
                Destroy(itemUis[4, i].GetComponent<ItemUI>().icon);
                itemUis[4, i].GetComponent<ItemUI>().currentItem = tempInventory[i]; //.GetComponent<Hook>().invIcon;
                itemUis[4, i].GetComponent<ItemUI>().Draw(false, 4, i);
            }
            else 
            {
                Destroy(itemUis[4, i].GetComponent<ItemUI>().icon);
                itemUis[4, i].GetComponent<ItemUI>().currentItem = noItemIcon;
                itemUis[4, i].GetComponent<ItemUI>().Draw(true, 4, i);
            }
        }
    }

    public void AddItem(int type) 
    {
        GameObject[] tempInventory;
        if (type == 0)
        {
            tempInventory = playerInventory.inventory.GetRods();
        }
        else if (type == 1)
        {
            tempInventory = playerInventory.inventory.GetBait();
        }
        else if (type == 2)
        {
            tempInventory = playerInventory.inventory.GetHooks();
        }
        else
        {
            tempInventory = playerInventory.inventory.GetReels();
        }

        for (int i = 0; i < itemUis.GetLength(1); i++)
        {
            if (tempInventory[i] != null)
            {
                Destroy(itemUis[type, i].GetComponent<ItemUI>().icon);
                itemUis[type, i].GetComponent<ItemUI>().currentItem = tempInventory[i];
                itemUis[type, i].GetComponent<ItemUI>().Draw(false, type, i);
            }
        }
    }

    public void AddCurrency(int newCurrency) 
    {
        currencyManager.SetCurrency(newCurrency);
    }

}
