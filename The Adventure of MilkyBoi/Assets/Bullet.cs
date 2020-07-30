using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem Spark;
    public float speed = 10f;
    public Health slider;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().damage(35f);
        }
        Instantiate(Spark, transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
