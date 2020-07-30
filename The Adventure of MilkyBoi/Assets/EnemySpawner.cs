using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefeb;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        Instantiate(EnemyPrefeb, transform.position, transform.rotation);
      
    }
}
