using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkProcessBar : MonoBehaviour
{
      public HealthSystem health = new HealthSystem();
      public static bool processCanRun = false;
    float process = 0;
    // Update is called once per frame

    void Start(){
        health.Damage(100);
        processCanRun = false;
   
    }
    void Update()
    {
        if (processCanRun)
        {
            process += 1 * Time.deltaTime;
            health.fill(process);
        }
        Vector3 scale = transform.localScale;
        scale.x = health.getHealthPercent();
        transform.localScale = scale;

        if (health.Health > 100.0f)
        {
            health.Health = 100;
        }
        else if(health.Health < 0f)
        {
            health.Health = 0;
        }
    }
}

