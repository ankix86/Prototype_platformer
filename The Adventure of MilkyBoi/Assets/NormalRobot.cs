using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRobot : MonoBehaviour
{

    public float speed = 10f;
    public LayerMask whatIsGround;
    public float checkRadius;
    public Transform checkGround;
    public Transform shootPosition;
    public int direction = 1;
    public GameObject Line;
    private LineRenderer lineRenderer;
    public Gradient red, blue;
    public float distance = 10;
    public LayerMask PlayerMask;

    //Gameobjects
    EnemyRange rader;

    //Physics
    private Rigidbody2D rigidbody;
    private Quaternion rotation;
   
    //Bools
    private bool isFacingRight = true;
    private bool isGrounded = true;
    private bool isAttacking = false;

 

    private void Start()
    {
        rader = new EnemyRange();
        Physics2D.queriesStartInColliders = false;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        lineRenderer = Instantiate(Line,new Vector3(0, 0, 0),Quaternion.identity).GetComponent<LineRenderer>();
    }
    void Update()
    {
        this.isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);
        RayCasting();
       
        if (isAttacking)
        {
            movement();
        }
        else
        {
            movement();
        }
    }

    void movement()
    {
        rigidbody.velocity = new Vector3(direction * speed, rigidbody.velocity.y);
        ChangeDirection();
        
        //Facing 
        if (direction > 0 && !isFacingRight)
        {
            isFacingRight = true;
            rotation.y = 0;
            transform.rotation = rotation;
        }
        else if (direction < 0 && isFacingRight)
        {
            isFacingRight = false;
            rotation.y = 180;
            transform.rotation = rotation;
        }
    }

    void ChangeDirection()
    {
        if (!isGrounded)
        {
            if (direction == 1)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
    }

    void RayCasting()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootPosition.position,shootPosition.right,distance,PlayerMask);
        if(hit != null)
        {
            if(hit)
            {
                isAttacking = true;
            }
        }
    }

    void Attack()
    {
        gameObject.transform.GetChild(1).GetComponent<AiGun>().Shoot();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

            if (direction == 1)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
    }
    void jump()
    {

        
    }
}
