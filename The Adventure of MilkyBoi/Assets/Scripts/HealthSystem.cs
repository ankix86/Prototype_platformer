using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    public float Health = 100;
    public float max = 100,min = 0;
    
    public void Damage(float damage)
    {
        Health -= damage;
    }

    public void fill(float value){
        Health += value;
    }

    public float getHealth() {
        return Health;
    }
    public float getHealthPercent()
    {
        return Health/ max;
    }
}
