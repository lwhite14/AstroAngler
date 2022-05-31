using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{   [SerializeField]
    private bool canBePressed;

    public  KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    private Transform buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectWithTag("buttons").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            
            if (canBePressed)
            {
                gameObject.gameObject.SetActive(false);

                

                if(Mathf.Abs(transform.position.y - buttons.position.y) > 0.25)
                {
                    Debug.Log("hit");
                    RhythmManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }else if(Mathf.Abs(transform.position.y - buttons.position.y) > 0.05){
                    Debug.Log("Good");
                    RhythmManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("perfect");
                    RhythmManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;

            RhythmManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
