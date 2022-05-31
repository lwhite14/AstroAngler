using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 90.0f;



    private void Update()
    {
        if (stateManager.instance.CanLure == true)
        { 
            float rotateHook = Input.GetAxis("Horizontal");
            float moveHook = Input.GetAxis("Vertical");

            GetComponent<Rigidbody2D>().velocity = transform.forward * moveSpeed * moveHook;

            transform.Rotate(Vector2.up * rotationSpeed * rotateHook * Time.deltaTime);
        }
    }

}
