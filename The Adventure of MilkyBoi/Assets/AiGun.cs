using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiGun : MonoBehaviour
{
    public float bulletSpeed;
    EnemyRange radar;
    //Objects
    public GameObject BulletPrefeb;
    public float fireRate = 1f;
    private float cooldown = 0f;

    public Transform shootPosition;

    public float aimSpeed;
    private Vector3 playerPos;
    private Quaternion rotation;


    private void Start()
    {
        radar = gameObject.transform.GetChild(2).GetComponent<EnemyRange>();
        shootPosition = gameObject.transform.GetChild(1).gameObject.transform;
    
    }

    void FixedUpdate()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Shoot();
        if (playerPos.x > transform.position.x)
        {
            rotation = Quaternion.LookRotation(transform.position - playerPos, Vector3.up);
        }
        else
        {
            rotation = Quaternion.LookRotation(transform.position - playerPos, -Vector3.up);
        }
        rotation.y = 0f;
        rotation.x = 0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * aimSpeed);
    }
    public void Shoot()
    {
        if (radar.playerInRange)
        {
            if (cooldown <= 0f)
            {
                if (BulletPrefeb != null)
                {
                    Instantiate(BulletPrefeb, shootPosition.position, transform.rotation);
                    cooldown = 1f / fireRate;
                }
            }
            cooldown -= Time.deltaTime;
        }
    }
}