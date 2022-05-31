using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x;
    float y;
    public float speed;
    public Rigidbody2D rigid;

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        rigid.velocity = new Vector2(x*speed*Time.deltaTime, y*speed*Time.deltaTime);
    }
}
