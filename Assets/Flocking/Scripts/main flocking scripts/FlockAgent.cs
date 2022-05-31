using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public string fishName;
    private bool isCaught = false;
    public bool baitable = true;
    public bool isRobot;

    private Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    private Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    public int fishLevel;

    public void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void initialise(Flock flock)
    {
        
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        if (!isCaught)
        {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
            if(velocity.x > 0)
            {
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
            }
            if (velocity.x < 0)
            {
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
            }
        }
    }


    //method: move towards hook
    public void MoveTowards()
    {
        gameObject.tag = "caughtfish";
        isCaught = true;
        
        this.GetComponent<MoveTowardsHook>().enabled = true;

    }
}
