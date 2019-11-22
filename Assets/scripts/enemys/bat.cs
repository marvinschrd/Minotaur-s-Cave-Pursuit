using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bat : MonoBehaviour
{
   private Vector3 target;
   [SerializeField] private Animator animator;
   [SerializeField] private int damage = 10;
   [SerializeField] float speed;

   private Rigidbody2D body;

    enum State
    {
        IDLE,
        CHASE_PLAYER,
        RETURN_NEST
    }

    State state = State.IDLE;

    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
    }

    // Update is called once per frame
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            target = other.transform.position;
            state = State.CHASE_PLAYER;
        }
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
