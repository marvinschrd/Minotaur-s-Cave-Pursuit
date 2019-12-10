using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBlock : MonoBehaviour
{
    [SerializeField] int damage = 200;
    [SerializeField] float timerToFall = 0.05f;
    float timeToFall = 0f;
    [SerializeField] float TimerToUp;
    float timeToUp;

    Rigidbody2D body;
    bool hitGround = false;
    Vector3 upPosition;
    [SerializeField] float speed;
    [SerializeField] AudioSource hittingGround;
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
        switch (state)
        {
            case State.IDLE:
                timeToFall = timerToFall;
                timeToUp = TimerToUp;
                hitGround = false;
                body.gravityScale = 0;
                break;
            case State.FALLING:
                {
                    timeToFall -= Time.deltaTime;
                    if (timeToFall <= 0)
                    {
                        body.gravityScale = 1;
                    }
                    if (hitGround)
                    {
                        hittingGround.Play();
                        state = State.WAITING;
                    }
                }
                break;
            case State.WAITING:
                {
                    body.gravityScale = 0;
                    timeToUp -= Time.deltaTime;
                    if (timeToUp <= 0)
                    {
                        state = State.MOVING_UP;
                    }
                }
                break;
            case State.MOVING_UP:
                {
                    body.velocity = (upPosition - transform.position).normalized * speed;
                    if (Vector3.Distance(transform.position, upPosition) < 0.01f)
                    {
                        body.gravityScale = 0;
                        state = State.IDLE;
                    }
                    break;
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            state = State.FALLING;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
        hitGround = true;
    }
}
