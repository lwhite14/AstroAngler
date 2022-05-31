using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Cast : MonoBehaviour
{

    public Animator castAnimation;

    private bool casting;
    private float atHookTime = 0.9f;
    private float atHook;

    private float holdDownStartTime;


    public Transform castPoint;
    public Transform CrossHair;
    public GameObject hookprefab;
    private float angle;
    private Quaternion q;

    //visual UI Slider
    public Slider CastSlider;
    public CanvasGroup ChargeCanvas;
    public float sliderAlpha;

    // Start is called before the first frame update
    void Start()
    {
        //UI Slider Update
        ChargeCanvas.alpha = sliderAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && stateManager.instance.IsCast == false && stateManager.instance.End == false)
        {
            
            holdDownStartTime = Time.time;

            // UI Slider Update
            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                ChargeCanvas.alpha = 1;
            }
        }
        if (Input.GetMouseButton(0) && stateManager.instance.IsCast == false && stateManager.instance.End == false)
        {
            float holdDownTime = Time.time - holdDownStartTime;

            // UI Slider Update
            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                //CastSlider.value = holdDownTime;
                calculateForce(holdDownTime);
            }

         }
         if (Input.GetMouseButtonUp(0) && stateManager.instance.IsCast == false && stateManager.instance.End == false)
         {
            float holdDownTime = Time.time - holdDownStartTime;
            calculateForce(holdDownTime);

            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                stateManager.instance.IsCast = true;
                casting = true;
                CastHookAnim();
            }
                

            // UI Slider Update
            CastSlider.value = 0;
         }

        if (casting && Time.time > atHook)
        {
            CastHook();
        }
    }

    void CastHookAnim()
    {
        castAnimation.Play("Cast");
        atHook = Time.time + atHookTime;
        casting = true;

        //UI Slider Update
        ChargeCanvas.alpha = sliderAlpha;
    }

    void CastHook()
    {
        casting = false;
        Vector3 dir = CrossHair.position - castPoint.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(0f, 0f, angle);



        Instantiate(hookprefab, castPoint.position, q);
    }

    private void calculateForce(float time)
    {
        float maxForce = 2f;
        float holdTime = Mathf.Clamp01(time / maxForce);
        CastSlider.value = holdTime;
        GameObject.Find("VelocitySlider").GetComponent<Slider>().value = holdTime;
    }

}
