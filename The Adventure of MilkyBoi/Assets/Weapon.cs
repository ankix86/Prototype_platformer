using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Gun
    public float bulletSpeed;

    //Objects
    public GameObject BulletPrefeb;
    public float fireRate = 1f;
    private float cooldown = 0f;

    public Transform shootPosition;

    public float offset;

    private void Start()
    {
        shootPosition = gameObject.transform.GetChild(1).gameObject.transform;
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -RotZ + offset);

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if (cooldown <= 0f)
        {
            Instantiate(BulletPrefeb, shootPosition.position,transform.rotation);
            cooldown = 1f / fireRate;
        }
        cooldown -= Time.deltaTime;
 
    }
}
