using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] private Animator ani;

    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fishMarker;

    float fishPosition;
    float fishDestination;

    float fishTimer;

    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize;
    [SerializeField] float hookPower = 5f;
    float hookProgress = 1f;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookDegredationPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform lifeBarContainer;

    bool pause = false;

    private AudioSource theMusic;

    [SerializeField]
    private AudioLogic audioLogic;
    

    private void OnEnable()
    {
        ani.SetTrigger("start");
        theMusic.Play();
        audioLogic.StopBackgroundMusic();
        hookProgress = 1f;
        

        if(stateManager.instance.GetFish().GetComponent<FlockAgent>().fishLevel == 1) {
            timerMultiplicator = 1f;
            fishSpeed = 2.5f;
            hookDegredationPower = 0.22f;
        }
        if (stateManager.instance.GetFish().GetComponent<FlockAgent>().fishLevel == 2)
        {
            timerMultiplicator = 1.8f;
            fishSpeed = 3f;
            hookDegredationPower = 0.24f;
        }
        if (stateManager.instance.GetFish().GetComponent<FlockAgent>().fishLevel == 3)
        {
            timerMultiplicator = 2.4f;
            fishSpeed = 3.5f;
            hookDegredationPower = 0.26f;
        }
        if (stateManager.instance.GetFish().GetComponent<FlockAgent>().fishLevel == 4)
        {
            timerMultiplicator = 3f;
            fishSpeed = 4;
            hookDegredationPower = 0.28f;
        }
        if (stateManager.instance.GetFish().GetComponent<FlockAgent>().fishLevel == 5)
        {
            timerMultiplicator = 3.5f;
            fishSpeed = 5;
            hookDegredationPower = 0.3f;
        }


        //code for hook area based on rod equipped goes below
        if (PlayerStats.instance.catchDifficulty == 1)
        {
            hookSize = 0.12f;
        }
        if (PlayerStats.instance.catchDifficulty == 2)
        {
            hookSize = 0.15f;
        }
        if (PlayerStats.instance.catchDifficulty == 3)
        {
            hookSize = 0.18f;
        }
        if (PlayerStats.instance.catchDifficulty == 4)
        {
            hookSize = 0.21f;
        }
        if (PlayerStats.instance.catchDifficulty == 5)
        {
            hookSize = 0.24f;
        }
        if (PlayerStats.instance.catchDifficulty == 6)
        {

        }
        Resize();
        fishPosition = 0;
        hookPosition = hookSize / 2;
    }
    private void Awake()
    {
        ani = gameObject.GetComponent<Animator>();
        theMusic = GetComponent<AudioSource>();
    }

    

    
    private void Update()
    {
        if (pause) { return; }
        Fish();
        Hook();
        LifeCheck();
        
    }

    private void Resize()
    {
        Vector3 scale = new Vector3(40f, 1f, 1f); ;
        hook.localScale = scale;
        Debug.Log(hook.localScale);
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;

        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);

        ls.y = (distance / ySize * hookSize) / 4;
        hook.localScale = ls;
        Debug.Log(ls);
        
    }

    void Hook()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime * 3f;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime * 1.7f;
        

        hookPosition += hookPullVelocity;
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
        
        if(hookPosition <= hookSize / 2 || hookPosition >= 1 - hookSize / 2)
        {
            hookPullVelocity = 0;
        }

    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fishMarker.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);

    }

    void LifeCheck()
    {
        Vector3 ls2 = lifeBarContainer.localScale;

        ls2.y = hookProgress;
        lifeBarContainer.localScale = ls2;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if(min < fishPosition && max > fishPosition)
        {
            //code to reel the fish in
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {

            hookProgress -= hookDegredationPower * Time.deltaTime;
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);

        if(hookProgress <= 0f)
        {
            theMusic.Stop();
            audioLogic.StopMiniGameMusic();
            audioLogic.StartBackgroundMusic();
            stateManager.instance.fishEscape();
        }

        
    }

    public void success()
    {
        ani.SetTrigger("end");
        theMusic.Stop();
        audioLogic.StopMiniGameMusic();
        audioLogic.StartBackgroundMusic();
        
        this.enabled = false;
    }

}
