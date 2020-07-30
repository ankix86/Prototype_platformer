using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMan : MonoBehaviour
{
    public enum State
    {
        PATROLLING,
        Idle,
        ATTACKING
    }

    public GameObject bullet;
    public int direction = 1;
    public Transform checkGround;
    public LayerMask whatIsGround;
    bool isGrounded;
    public float checkRadius;
    private bool collideLadder = false;
    bool isFacingRight = true;
    private Animator animator;
    public State currentState = State.Idle;
    public float movementSpeed;
    Rigidbody2D rb;
    Quaternion rotation;
    public GameObject shootPoint;
    public static bool isHeartDown = false;
   
   

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        this.isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);
        switch (currentState)
        {
            case State.Idle: {
                    Idle();
                    animator.SetBool("isWalking", false);
                    break;
                }
            case State.PATROLLING:
                {
                    Patrollling();
                    animator.SetBool("isWalking", true);
                    break;
                }
            case State.ATTACKING:
                {
                    Attack();
                    break;
                }
        }

        rayCasting();

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
    void Patrollling()
    {
        rb.isKinematic = false;
        rb.gravityScale = 1;
        ChangeDirection();
        rayCasting();
        rb.velocity = new Vector2(direction * movementSpeed, rb.velocity.y);

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

    void Attack()
    {
        GameObject Tbullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        Tbullet.GetComponent<Rigidbody2D>().AddForce(direction * Vector2.right * 1000);
        Destroy(Tbullet, 3f);
    }

    void rayCasting()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, shootPoint.transform.right,5.0f);
        if (hit)
        {
            if (hit.transform.gameObject.CompareTag("hotPot") || hit.transform.gameObject.CompareTag("Enemy"))
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
            else if (hit.transform.gameObject.CompareTag("Player"))
            {
                currentState = State.ATTACKING;
            }
        }
        else
        {
            currentState = State.PATROLLING;
        }
    }
    void Idle()
    {
      
    }

    void Death()
    {
        if(GameObject.Find("HealthBarBG/HealthBar").GetComponent<HealthBar>().health.getHealth() == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            currentState = State.ATTACKING;
            animator.SetBool("isEating", true);
            Debug.Log("Eating");
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            currentState = State.PATROLLING;
            animator.SetBool("isEating", false);
            Debug.Log("EatingOut");
        }
    }

   
}
