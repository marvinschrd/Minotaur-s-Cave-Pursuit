using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   Rigidbody2D body;
   [SerializeField] public Animator Animator;
   PlayerHealth playerHealth;
   Vector2 direction;
   float horizontalMove;
    
   [SerializeField]
   float speed = 2;
   [SerializeField]
   float maxSpeed = 10;

   [Header("Jump")]
   [SerializeField] float jumpForce = 5;
   [SerializeField] float raycastJumpLength = 0.6f;
   [SerializeField] float timeStopJump = 0.1f;
   float timerStopJump = 0f;
   bool canJump = false;
   int touchedWall = 0;

   bool facingRight = true;
   bool facingLeft = false;

   Vector3 startPosition;
   Vector3 checkpointPosition;

   [SerializeField] float freezeTime;
   float freezeTimer;
   bool freezed = false;

   [SerializeField] AudioSource footSteps;
   [SerializeField] AudioSource jump;
   [SerializeField] AudioSource keySound;
   bool canPlayFootSteps = true;

   bool key = false;
   [SerializeField] GameObject keyUI;
    void Start()
    {
        startPosition = transform.position;
        body = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }
    void FixedUpdate()
    {
        body.velocity = direction;
    }    
    void JumpCheck()
    {
        timerStopJump -= Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastJumpLength, 1 << LayerMask.NameToLayer("platform"));
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastJumpLength, 1 << LayerMask.NameToLayer("wall"));
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastJumpLength, 1 << LayerMask.NameToLayer("wall"));
        if (timerStopJump <= 0)
        {
            if (hit.rigidbody != null)
            {
                touchedWall = 0;
                canJump = true;
            }
            else if (hitRight.rigidbody != null && touchedWall == 0 || hitRight.rigidbody != null && touchedWall == 2)
            {
                canJump = true;
                touchedWall = 1;
            }
            else if (hitLeft.rigidbody != null && touchedWall == 0 || hitLeft.rigidbody != null && touchedWall == 1)
            {
                canJump = true;
                touchedWall = 2;
            }
        }

        if (Input.GetAxis("UpArrow") > 0.1f && canJump)
        {
            jump.Play();
            Debug.Log("Jump");
            direction = new Vector2(body.velocity.x, jumpForce);
            canJump = false;
            body.gravityScale = 1;
            footSteps.volume = 0;
            timerStopJump = timeStopJump;
        }
    }
    public void checkpointReached(Vector2 NextCheckpointPosition)
    {
        checkpointPosition =  NextCheckpointPosition;
        Debug.Log(NextCheckpointPosition);
    }
    public void Respawn()
    {
        Animator.SetBool("isDead", false);
        transform.position = checkpointPosition;
        playerHealth.loseLife();
        playerHealth.resetHealth();
    }
    void Update()
    {
        if (freezed)
        {
            freezeTimer -= Time.deltaTime;
            Animator.SetFloat("speed",0);
            if (freezeTimer <= 0)
            {
                Animator.SetBool("freezed", false);
                body.bodyType = RigidbodyType2D.Dynamic;
                freezed = false;
            }
        }
         direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (!freezed)
        {
            Animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        }
         horizontalMove = Input.GetAxis("Horizontal");
        if (body.velocity.y < -0.1f)
        {
            direction = new Vector2(body.velocity.x, body.velocity.y * 1.01f);
        }
        JumpCheck();
        if (horizontalMove < 0 && !facingLeft)
        {
            facingLeft = true;
            facingRight = false;
             Animator.transform.Rotate(0, 180, 0);
        }
        if (horizontalMove > 0 && !facingRight)
        {
            facingRight = true;
            facingLeft = false;
            Animator.transform.Rotate(0, 180, 0);
        }
        walkingSound();
    }
    public void freeze()
    {
        freezeTimer = freezeTime;
        body.bodyType = RigidbodyType2D.Static;
        freezed = true;
    }
    public void TakeKey()
    {
        keySound.Play();
        key = true;
        keyUI.SetActive(true);
    }
   public bool Usekey()
    {
        bool usingKey = key;
        key = false;
        return usingKey;   
    }
    private void walkingSound()
    {
        if (canJump)
        {
            footSteps.volume = 0.5f;
            if (horizontalMove > 0 && canPlayFootSteps)
            {
                footSteps.Play();
                canPlayFootSteps = false;
            }
            if (horizontalMove < 0 && canPlayFootSteps)
            {
                footSteps.Play();
                canPlayFootSteps = false;
            }
            if (horizontalMove == 0)
            {
                footSteps.Stop();
                canPlayFootSteps = true;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.down * raycastJumpLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.right * raycastJumpLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.left * raycastJumpLength);
    }
   
}