using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreate : MonoBehaviour
{
    //Get Planets
    [SerializeField]
    private GameObject[] planets;

    //Set up colider variables
    [SerializeField]
    public Collider2D collider;
    private Vector3 cMin, cMax;

    //Get Number of Planets to Spawn
    [SerializeField]
    private int maxPlanets;

    //set co-ordinates Planets Spawn in
    private float xMin, xMax, yMin, yMax;

    

    // Start is called before the first frame update
    public void Start()
    {
        collider = GetComponent<Collider2D>();
        cMin = collider.bounds.min;
        cMax = collider.bounds.max;

        xMin = cMin.x;
        xMax = cMax.x;
        yMin = cMin.y;
        yMax = cMax.y;

        //added by James to disable collision with hook
        collider.enabled = !collider.enabled;
        /////

        int count = 1;
        while(count <= maxPlanets)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
            Quaternion rotate = new Quaternion(0, 0, 0, 0);

            if (Random.Range(0, 5) == 0)
            {
                Instantiate(planets[0], pos, rotate);
            }
            else if (Random.Range(0, 5) == 1)
            {
                Instantiate(planets[1], pos, rotate);
            }
            else if (Random.Range(0, 5) == 2)
            {
                Instantiate(planets[2], pos, rotate);
            }
            else if (Random.Range(0, 5) == 3)
            {
                Instantiate(planets[3], pos, rotate);
            }
            else if (Random.Range(0, 5) == 3)
            {
                Instantiate(planets[4], pos, rotate);
            }
            count++;
        }

        
        //added by James to get pathfinder to scan the generated map for Fish AI
        //AstarPath.active.Scan();

    }
}
