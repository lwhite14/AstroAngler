using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotOne : MonoBehaviour
{
    
    public Vector2 lureTo;

    void Awake()
    {
        lureTo = GameObject.FindGameObjectWithTag("castPoint").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "caughtfish" && stateManager.instance.CanLure == true)
        {
            stateManager.instance.setCaughtFish(collision.gameObject);

            //add code later for catching multiple fish
            stateManager.instance.CanLure = false;

            stateManager.instance.HasCaught = true;
        }
    }

    private void Update()
    {
        if(stateManager.instance.HasCaught == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, lureTo, 3f * PlayerStats.instance.speed * Time.deltaTime);
        }
        if (Vector2.Distance(this.transform.position, lureTo ) < 0.5f && stateManager.instance.HasCaught == true)
        {
            Destroy(this);
            stateManager.instance.Success();
        }
    }
}
