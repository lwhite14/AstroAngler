using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTab : MonoBehaviour
{
    public Animator anim;

    public void OnPress() 
    {
        if (anim.GetBool("isOpen") == false)
        {
            anim.SetBool("isOpen", true);
        }
        else 
        {
            anim.SetBool("isOpen", false);
        }
    }
}
