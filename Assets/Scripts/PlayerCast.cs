using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast : MonoBehaviour
{
    private Camera theCam;
    public GameObject CrossHair;
    public Vector2 pivotPoint;
    
    public void Start()
    {
        theCam = Camera.main; 
    }

    
    public void Update()
    {
        MoveCrossHair();    
    }

    

    private void MoveCrossHair()
    {
        Vector3 aim = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(aim.x - screenPoint.x, aim.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        if( angle < -15)
        {
            angle = -15;
        }else if(angle > 30)
        {
            angle =30;
        }else
        {
            CrossHair.transform.rotation = Quaternion.Euler(0f, 0f, angle);   
        }
    }
}