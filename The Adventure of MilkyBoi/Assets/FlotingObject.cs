using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotingObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private float spawnPosY;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spawnPosY = gameObject.transform.position.y;
    }

    void Update()
    {
        if (transform.position.y <= spawnPosY + 0.1f)
        {
            rb.gravityScale = -0.1f;
        }
        else if (transform.position.y >= spawnPosY - 0.1f)
        {
            rb.gravityScale = 0.1f;
        }
    }
}
