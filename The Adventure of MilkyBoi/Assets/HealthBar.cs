using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthSystem health = new HealthSystem();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            health.Damage(10);
        }
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
