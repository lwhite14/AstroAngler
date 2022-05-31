using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookLaunch : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    private bool startSlow = false;

    public GameObject hookRotatePoint;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("VelocitySlider").GetComponent<Slider>().value;
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        rb.gravityScale = 1;

        rb.velocity = transform.right * speed * playerStats.power * 15;

        CameraFollow.instance.setTarget(this.gameObject);

        
    }

    private void Update()
    {
        
        if (transform.position.x > 0f || transform.position.y < 0f)
        {
            startSlow = true;
        }
        if (startSlow == true)
        {
            rb.AddForce(new Vector2(-rb.velocity.x, -rb.velocity.y) * 0.6f * Time.deltaTime , ForceMode2D.Impulse);
        }
        if (rb.velocity.x < 0.3f && rb.velocity.y < 0.3f && stateManager.instance.HasCaught == false && stateManager.instance.GotAway == false)
        {
            stateManager.instance.CanLure = true;

            hookRotatePoint.transform.rotation = Quaternion.Lerp(hookRotatePoint.transform.rotation, Quaternion.Euler(0,0,90), 0.05f);
        }
        else
        {
            Vector3 dir = rb.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            hookRotatePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        if(stateManager.instance.HasCaught == true)
        {
            Vector3 dir = rb.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            hookRotatePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if(transform.position.y > 60f )
        {
            rb.gravityScale = 1;
        }
        else if (transform.position.y < -60f)
        {
            rb.gravityScale = -1;
        }
        else
        {
            rb.gravityScale = 0;
        }
        
    }


}
