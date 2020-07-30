using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanRotation : MonoBehaviour
{
    public float rotation_speed;
    void Update()
    {       
        transform.Rotate(0, 0, rotation_speed * 500 * Time.deltaTime);
    }
}
