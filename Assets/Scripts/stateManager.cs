using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stateManager : MonoBehaviour
{
    [SerializeField]
    private bool isCast = false;
    [SerializeField]
    private bool canLure = false;
    [SerializeField]
    private bool hasCaught = false;
    [SerializeField]
    private bool gotAway = false;

    private GameObject caughtFish;

    public Camera theCam;

    public GameObject minigame;

    public GameObject canvas;
    public GameObject allText;
    public Transform textSpawn;
    public bool End = false;
    private GameObject curText;
    

    private bool miniGameStart = false;

    public static stateManager instance = null;

    public PlayerInventory playerInventory;

    public bool IsCast { get => isCast; set => isCast = value; }
    public bool CanLure { get => canLure; set => canLure = value; }
    public bool HasCaught { get => hasCaught; set => hasCaught = value; }
    public bool GotAway { get => gotAway; set => gotAway = value; }



    // Start is called before the first frame update

    void Awake()
    {
        if(instance != null)
        {
            Destroy(GetComponent<stateManager>());
            return;
        }
        instance = this;
        
    }
   

    // Update is called once per frame
    void Update()
    {
        if (hasCaught == true && miniGameStart == false)
        {
            minigame.GetComponent<FishingMiniGame>().enabled = true; 
            miniGameStart = true;
        }
        if (End == true)
        {
            if(Input.GetMouseButtonUp(0)){
                Destroy(curText);
                Destroy(caughtFish);
                Invoke("ResetScene", 0.1f);
                End = false;
            }
        }
    }

    public void setCaughtFish(GameObject fish)
    {
        caughtFish = fish;
    }

   
    public GameObject GetFish()
    {
        return caughtFish;
    }
    

    public void fishEscape()
    {
        hasCaught = false;
        gotAway = true;
        caughtFish.GetComponent<MoveTowardsHook>().enabled = false;
        caughtFish.GetComponent<FlockAgent>().enabled = true;

        minigame.GetComponent<FishingMiniGame>().success();
        allText.transform.GetChild(0).GetComponent<Text>().text = "Better Luck Next Time";
        curText = Instantiate(allText, textSpawn.position, Quaternion.identity, canvas.transform);
        Invoke("end", 1);


        

    }

    

    // code for when a fish is bought back successfully
    public void Success()
    {   
        minigame.GetComponent<FishingMiniGame>().success();
        Debug.Log("Fish Caught");
        allText.transform.GetChild(0).GetComponent<Text>().text = "Congratulations You Caught A " + caughtFish.GetComponent<FlockAgent>().fishName;
        curText = Instantiate(allText, textSpawn.position, Quaternion.identity,canvas.transform );
        Invoke("end", 1);



        playerInventory.AddFish(Instantiate(caughtFish, new Vector3(-32, -8, 0), Quaternion.identity) as GameObject);
        //insert code for what happens when a fish is caught
    }

    public void ResetScene()
    {
        theCam.GetComponent<MoveToOrigin>().enabled = true;
        Destroy(GameObject.FindGameObjectWithTag("hookParent"));

        GameObject[] allFlock = GameObject.FindGameObjectsWithTag("flock");
        foreach (GameObject flock in allFlock)
            GameObject.Destroy(flock);
        
        isCast = false;
        canLure = false;
         hasCaught = false;
         miniGameStart = false;
        gotAway = false;
        
    }

    private void end()
    {
        End = true;
    }
}
