using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    [System.NonSerialized] public GameObject rodSelected;
    [System.NonSerialized] public GameObject baitSelected;
    [System.NonSerialized] public GameObject hookSelected;
    [System.NonSerialized] public GameObject reelSelected;
    public InventoryManager inventoryManager;

    public void AddFish(GameObject newFish) 
    {
        inventory.AddFish(newFish);
        inventoryManager.AddFish();
    }

    public void SellFish(int index) 
    {
        int sellingPrice = inventory.SellFish(index);
        inventoryManager.AddCurrency(sellingPrice);
    }

    public void AddRod(GameObject newRod) 
    {
        inventory.AddRod(newRod);
        inventoryManager.AddItem(0);
    }

    public void AddBait(GameObject newBait)
    {
        inventory.AddBait(newBait);
        inventoryManager.AddItem(1);
    }

    public void AddHook(GameObject newHook)
    {
        inventory.AddHook(newHook);
        inventoryManager.AddItem(2);
    }

    public void AddReel(GameObject newReel)
    {
        inventory.AddReel(newReel);
        inventoryManager.AddItem(3);
    }
}
