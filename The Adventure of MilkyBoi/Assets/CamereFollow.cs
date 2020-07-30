using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = .15f;

    //Enable or set min Yvalue
    public bool YminEnable = false;
    public float Ymin = 0;
    //Enable or set max Yvalue
    public bool YmaxEnable = false;
    public float Ymax = 0;

    //Enable or set max Xvalue
    public bool XminEnable = false;
    public float Xmin = 0;

    //Enable or set max Xvalue
    public bool XmaxEnable = false;
    public float Xmax = 0;

    private Vector3 velocity = Vector3.zero;
    private void Update()

    {
        Vector3 position = target.position;

        if (XminEnable && XmaxEnable) 
          position.x = Mathf.Clamp(target.position.x, Xmin, Xmax);

        else if (XminEnable)
            position.x = Mathf.Clamp(target.position.x, Xmin,target.position.x);

        else if (XmaxEnable)
            position.x = Mathf.Clamp(target.position.x,target.position.x, Xmax);

        if (YminEnable && YmaxEnable)
            position.y = Mathf.Clamp(target.position.y, Ymin, Ymax);

        else if (YminEnable)
            position.y = Mathf.Clamp(target.position.y, Ymin, target.position.y);

        else if (YmaxEnable)
            position.y = Mathf.Clamp(target.position.y, target.position.y, Ymax);


        position.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothTime);
    }

}
