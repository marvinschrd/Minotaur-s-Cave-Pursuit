using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bat : MonoBehaviour
{
   Vector3 target;
   [SerializeField] Animator animator;
   [SerializeField] int damage = 10;
   [SerializeField] float speed;
   bool isDetected = false;
   Rigidbody2D body;
   Vector3 originalPosition;

    enum State
    {
        IDLE,
        CHASE_PLAYER,
        RETURN_NEST
    }
    State state = State.IDLE;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
    }
    void Update()
    {
        switch (state)
        {
            case State.IDLE:
                animator.SetBool("isChasing", false);
                break;
            case State.CHASE_PLAYER:
                body.velocity = (target - transform.position).normalized * speed;
                animator.SetBool("isChasing", true);

                if (Vector3.Distance(transform.position, target) < 0.5f)
                {
                    state = State.RETURN_NEST;
                }
                break;
            case State.RETURN_NEST:
                animator.SetBool("isChasing", false);
                body.velocity = (originalPosition - transform.position).normalized * speed;

                if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
                {
                    state = State.IDLE;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public void playerDetected(Vector3 targetFromDetector)
    {
        state = State.CHASE_PLAYER;
        target = targetFromDetector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}
