using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsHook : MonoBehaviour
{
    private Vector2 finalPos;
    public Transform mouth;

    public void Start()
    {
        this.GetComponent<FlockAgent>().enabled = false;
        

    }

    public void Update()
    {
        

        finalPos = GameObject.FindGameObjectWithTag("Hook").transform.position;
        if ((Vector2)mouth.position != finalPos)
        {


            LookAt2D(this.transform, finalPos);


            transform.position = Vector2.MoveTowards(transform.position, finalPos, 3f * PlayerStats.instance.speed * Time.deltaTime) ;
            
        }

        
        
    }

     private void LookAt2D(Transform transform, Vector2 target)
     {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
      }



}
