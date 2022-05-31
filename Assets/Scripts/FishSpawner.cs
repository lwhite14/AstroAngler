using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //get fish to Spawn
    public GameObject[] allFlocks;

    private int fishLvl;

    private Vector2 pos;

    //Set up colider variables
    public Collider2D colliderLvl1;
    public Collider2D colliderLvl2;
    public Collider2D colliderLvl3;
    public Collider2D colliderLvl4;
    public Collider2D colliderLvl5;


    //Get Number of Fish to Spawn
    private int maxFish;
    

    public void Start()
    {
        spawn();
        
    }

    

    // Update is called once per frame
    public void Update()
    {
        if(GameObject.FindWithTag("flock") == null)
        {
           spawn();
        }
    }

    private void spawn()
    {
        colliderLvl1.enabled = true;
        colliderLvl2.enabled = true;
        colliderLvl3.enabled = true;
        colliderLvl4.enabled = true;
        colliderLvl5.enabled = true;
        for (int i = 0; i < allFlocks.Length; i++)
        {
            fishLvl = allFlocks[i].GetComponent<Flock>().agentPrefab.fishLevel;
            maxFish = allFlocks[i].GetComponent<Flock>().amountOfFlock;
            int count = 1;
            while (count <= maxFish)
            {
                if(fishLvl == 1)
                {
                    pos = new Vector3(Random.Range(colliderLvl1.bounds.min.x, colliderLvl1.bounds.max.x), Random.Range(colliderLvl1.bounds.min.y, colliderLvl1.bounds.max.y));
                }
                if (fishLvl == 2)
                {
                    pos = new Vector3(Random.Range(colliderLvl2.bounds.min.x, colliderLvl2.bounds.max.x), Random.Range(colliderLvl2.bounds.min.y, colliderLvl2.bounds.max.y));
                }
                if (fishLvl == 3)
                {
                    pos = new Vector3(Random.Range(colliderLvl3.bounds.min.x, colliderLvl3.bounds.max.x), Random.Range(colliderLvl3.bounds.min.y, colliderLvl3.bounds.max.y));
                }
                if (fishLvl == 4)
                {
                    pos = new Vector3(Random.Range(colliderLvl4.bounds.min.x, colliderLvl4.bounds.max.x), Random.Range(colliderLvl4.bounds.min.y, colliderLvl4.bounds.max.y));
                }
                if (fishLvl == 5)
                {
                    pos = new Vector3(Random.Range(colliderLvl5.bounds.min.x, colliderLvl5.bounds.max.x), Random.Range(colliderLvl5.bounds.min.y, colliderLvl5.bounds.max.y));
                }

                Quaternion rotate = new Quaternion(0, 0, 0, 0);

                Instantiate(allFlocks[i], pos, rotate);
                count++;
            }
        }
        colliderLvl1.enabled = false;
        colliderLvl2.enabled = false;
        colliderLvl3.enabled = false;
        colliderLvl4.enabled = false;
        colliderLvl5.enabled = false;
    }
}
