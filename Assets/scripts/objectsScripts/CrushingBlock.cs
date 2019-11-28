using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBlock : MonoBehaviour
{
    [SerializeField] private int damage = 200;
    [SerializeField] float timerToFall = 0.05f;
    private float timeToFall = 0f;
    [SerializeField] float TimerToUp;
    private float timeToUp;

    private Rigidbody2D body;
    private bool isTriggered = false;
    private Vector3 upPosition;
    [SerializeField] float speed;
    private void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        upPosition = transform.position;
    }

    enum State
    {
        IDLE,
        FALLING,
        WAITING,
        MOVING_UP
    }

    State state = State.IDLE;

    private void Update()
    {
        //TimeBeforeFalling();
        switch (state)
        {
            case State.IDLE:
              //  Debug.Log("IDLE");
                timeToFall = timerToFall;
                timeToUp = TimerToUp;
                isTriggered = false;
                body.bodyType = RigidbodyType2D.Static;
                break;
            case State.FALLING:
                {
                   // Debug.Log("FALLING");
                    timeToFall -= Time.deltaTime;
                   // Debug.Log(timeToFall);
                    if (timeToFall <= 0)
                    {
                        body.bodyType = RigidbodyType2D.Dynamic;
                    }
                    if (isTriggered)
                    {
                        state = State.WAITING;
                    }
                }
                break;
            case State.WAITING:
                {
                    //Debug.Log("isWaiting");

                    timeToUp -= Time.deltaTime;
                    //Debug.Log(timeToUp);
                    if (timeToUp <= 0)
                    {
                        state = State.MOVING_UP;
                    }

                }
                break;
            case State.MOVING_UP:
                {
                    Debug.Log("moving Up");
                   
                    body.velocity = (upPosition - transform.position).normalized * speed;
                    if (Vector3.Distance(transform.position, upPosition) < 0.01f)
                    {
                        state = State.IDLE;
                    }
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        state = State.FALLING;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //isTriggered = true;

    //}
    //void TimeBeforeFalling()
    //{
    //    if (isTriggered == true)
    //    {
    //        timeToFall -= Time.deltaTime;
    //        Debug.Log(timeToFall);
    //        if (timeToFall <= 0)
    //        {
    //            body.bodyType = RigidbodyType2D.Dynamic;
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
        isTriggered = true;
    }
}
