using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour
{

   private Rigidbody2D body;
   private Vector2 direction;
   private bool isTriggered = false;
   [SerializeField] float speed;
    private Vector2 startingPosition;
    [SerializeField] float timerToSpawnBack;
    private float timeToSpawnBack;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
       
    }

   enum State
    {
        IDLE,
        MOVING,
        WAITING,
        SPAWNING_BACK
    }
    State state = State.IDLE;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(state);
        //if (isTriggered)
        //{

        //   if(body.velocity.magnitude <1)
        //    {
        //       // Debug.Log(body.velocity.y);
        //        direction = new Vector2(speed, body.velocity.y);
        //        body.velocity = direction;
        //    }

        //}

        switch (state)
        {
            case State.IDLE:
                timeToSpawnBack = timerToSpawnBack;
                break;
            case State.MOVING:
                if (body.velocity.magnitude < 1)
                {
                    // Debug.Log(body.velocity.y);
                    direction = new Vector2(speed, body.velocity.y);
                    body.velocity = direction;
                }
                break;
            case State.WAITING:
                timeToSpawnBack -= Time.deltaTime;
                if (timeToSpawnBack <= 0)
                {
                    state = State.SPAWNING_BACK;
                }
                break;
            case State.SPAWNING_BACK:
                transform.position = startingPosition;
                state = State.IDLE;
                break;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
        isTriggered = true;
        state = State.MOVING;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("exit");
        isTriggered = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "cartStopper" && !isTriggered)
        {
            //Debug.Log("WAITING");
            state = State.WAITING;
        }
    }
}
