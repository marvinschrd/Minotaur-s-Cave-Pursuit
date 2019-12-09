using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour
{

   Rigidbody2D body;
   Vector2 direction;
   bool isTriggered = false;
   [SerializeField] float speed;
   Vector2 startingPosition;
   [SerializeField] float timerToSpawnBack;
   float timeToSpawnBack;
   [SerializeField] AudioSource cartRolling;
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
    void Update()
    {
        switch (state)
        {
            case State.IDLE:
                timeToSpawnBack = timerToSpawnBack;
                break;
            case State.MOVING:
                if (body.velocity.magnitude < 1)
                {
                    Debug.Log("moving");
                     Debug.Log(body.velocity.y);
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
            cartRolling.Play();
            isTriggered = true;
            state = State.MOVING; 
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "cartStopper" && !isTriggered)
        {
            cartRolling.Stop();
            state = State.WAITING;
        }
    }
}
