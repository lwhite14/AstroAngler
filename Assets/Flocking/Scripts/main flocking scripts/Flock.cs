using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Transform spawnPoint;
    GameObject hook;
    
    private bool chance = false;

    public FlockAgent agentPrefab;
    private List<FlockAgent> agents = new List<FlockAgent>();
    
    public int range = 10;
    public int amountOfFlock;
    public FlockBehaviour behaviour;

    [Range(1, 15)]
    public int startingCount = 250;
    const float AgentDensity = 1f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    public void Start()
    {
        spawnPoint = gameObject.transform;
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                (Vector2)spawnPoint.position + Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "SunFish_Agent" + i;
            newAgent.initialise(this);
            agents.Add(newAgent);
        }
    }

    
    public void Update()
    {
        hook = GameObject.FindGameObjectWithTag("Hook");
        foreach (FlockAgent agent in agents)
        {

            if (hook != null && stateManager.instance.CanLure == true && Vector2.Distance(hook.transform.position, agent.transform.position) < range && agent.baitable == true)
            {
                stateManager.instance.CanLure = false;
                chance = attractChance(agent.fishLevel, agent.isRobot);

                if (chance == true)
                {
                   
                    agent.MoveTowards();
                    
                }
                else if(chance == false) 
                {

                    agent.baitable = false;
                    Invoke("SetBoolBack", 3f);

                    List<Transform> context = getNearbyObjects(agent);
                    Vector2 move = behaviour.calculateMove(agent, context, this);
                    move *= driveFactor;
                    if (move.sqrMagnitude > squareMaxSpeed)
                    {
                        move = move.normalized * maxSpeed;
                    }
                    agent.Move(move);

                    
                }
            }

            else 
            {
                List<Transform> context = getNearbyObjects(agent);
                Vector2 move = behaviour.calculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
            agent.Move(move); 
            }
            
            
            
        }
    }

    private List<Transform> getNearbyObjects(FlockAgent agent)
    {
        
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);

            }
        }
        return context;
    }

     private bool attractChance(int fishLevel, bool isRobot)
    {
        if (PlayerStats.instance.attraction == 1)
        {
            if (fishLevel <= 1)
            {
                int randomNum = Random.Range(0, 9);
                bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
                return isLured[randomNum];
            }

        }
        if (PlayerStats.instance.attraction == 2)
        {

            if (fishLevel <= 2)
            {
                int randomNum = Random.Range(0, 9);
                bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
                return isLured[randomNum];
            }
        }
        if (PlayerStats.instance.attraction == 3)
        {


            if (fishLevel <= 3 )
            {
                int randomNum = Random.Range(0, 9);
                bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
                return isLured[randomNum];
            }

        }
        if (PlayerStats.instance.attraction == 4)
        {
            if (isRobot)
            {
                int randomNum = Random.Range(0, 9);
                bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
                return isLured[randomNum];
            }
        }
        if (PlayerStats.instance.attraction == 5)
        {

            if (fishLevel <= 4)
            {
                int randomNum = Random.Range(0, 9);
                bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
                return isLured[randomNum];
            }

        }
        if (PlayerStats.instance.attraction == 6)
        {

            if (fishLevel <= 5)
            {
                int randomNum = Random.Range(0, 9);
                bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
                return isLured[randomNum];
            }
        }
        return false;
    }

    private void SetBoolBack()
    {
        if (stateManager.instance.GotAway == false)
        {
            agentPrefab.baitable = true;
            stateManager.instance.CanLure = true;
        }
        
    }
   
}