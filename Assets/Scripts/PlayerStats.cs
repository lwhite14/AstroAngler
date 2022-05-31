using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public float power = 1;
    public float attraction = 1;
    public float catchDifficulty = 1;
    public float speed = 1;

    public static PlayerStats instance;

    private void Start()
    {
        instance = this;
    }

    public void FixedUpdate()
    {
        power = 1 * playerInventory.rodSelected.GetComponent<Rods>().power;
        attraction = 1 * playerInventory.baitSelected.GetComponent<Bait>().attraction;
        catchDifficulty = 1 * playerInventory.hookSelected.GetComponent<Hook>().catchDifficulty;
        speed = 1 * playerInventory.reelSelected.GetComponent<Reel>().speed;
    }



}
