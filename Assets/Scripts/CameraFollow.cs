using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Transform camTrans;

    public float smoothFloat = 0.125f;
    public Vector3 offset;

    public static CameraFollow instance;


    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.GetComponent<Transform>();
        instance = this;
    }

    private void Update()
    {
        //finds target to follow
        try
        {
            target = GameObject.FindGameObjectWithTag("Hook").transform;
        }
        catch { }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //sets camera to target
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    public void setTarget(GameObject T)
    {
        target = T.transform;
    }
}