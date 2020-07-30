using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskChacker : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -0.25f, 0));
        if (transform.position.y < -10f)
            transform.Translate(new Vector3(0, -transform.position.y, 0));

        for (int x = -80; x < 80; x++)
        {
            // Cast a ray straight down.
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(x / 4, transform.position.y, transform.position.z), Vector3.forward, Mathf.Infinity, 1 << 16);

            // If it hits something...
          
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
            else
            {
                Debug.DrawLine(transform.position,transform.position + transform.forward * Mathf.Infinity, Color.blue);
            }
        }
    }
}
