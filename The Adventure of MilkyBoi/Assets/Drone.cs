using UnityEngine;
using Pathfinding;

public class Drone : MonoBehaviour
{
    Rigidbody2D rgbd;
    public float speed;
    bool IsinB1;
    Vector3 b1, b2;
    public float xDistence,yDistence;

    
    enum State
    {
        Patrolling,
        Attacking,
        Track
    }
    State currentState;
    private bool playerInRange;
    Vector2 startPos;
    void Start()
    {
        rgbd = gameObject.transform.GetComponent<Rigidbody2D>();
        b1 = transform.position;
        b2 = transform.position;
        
        b1.x -= xDistence;
        b2.x += xDistence;

        b1.y -= yDistence;
        b2.y += yDistence;
        
        IsinB1 = false;
        playerInRange = false;
        currentState = State.Patrolling;
    }
    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.U))
        {
            if (gameObject.GetComponent<AIPath>().enabled == false)
            {
                gameObject.GetComponent<AIPath>().enabled = true;
                gameObject.GetComponent<AIDestinationSetter>().enabled = true;
                rgbd.constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                rgbd.constraints = RigidbodyConstraints2D.FreezePositionY;
                gameObject.GetComponent<AIPath>().enabled = false;
                gameObject.GetComponent<AIDestinationSetter>().enabled = false;
            }
        }
    
      
        if (playerInRange)
        {
            currentState = State.Attacking;
        }
        else
        {
            currentState = State.Patrolling;
        }
        AI_Behavior();
    }

    void AI_Behavior()
    {
        if (currentState == State.Patrolling)
        {
                if (IsinB1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, b2, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, b1, speed * Time.deltaTime);
                }

            if (transform.position.x <= b1.x)
                {
                    IsinB1 = true;
                }

            if (transform.position.x >= b2.x)
            {
                IsinB1 = false;
            }
        
        }
    }
}
