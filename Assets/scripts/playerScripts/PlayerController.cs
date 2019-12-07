using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
   [SerializeField] public Animator Animator;
    PlayerHealth playerHealth;
    Vector2 direction;
    float horizontalMove;
    
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float maxSpeed = 10;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5;
    [SerializeField] float raycastJumpLength = 0.6f;
    [SerializeField] float timeStopJump = 0.1f;
   private float timerStopJump = 0f;
   private bool canJump = false;
   private  int touchedWall = 0;

   private bool facingRight = true;
   private bool facingLeft = false;

   private Vector3 startPosition;
   private Vector3 checkpointPosition;

    [SerializeField] float freezeTime;
    float freezeTimer;
    bool freezed = false;

    [SerializeField] AudioSource footSteps;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource keySound;
    bool canPlayFootSteps = true;
    bool key = false;

    
    // Start is called before the first frame update
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

                //body.gravityScale = 0.2f;
                canJump = true;
                touchedWall = 1;
                Debug.Log(body.gravityScale);
            }
            else if (hitLeft.rigidbody != null && touchedWall == 0 || hitLeft.rigidbody != null && touchedWall == 1)
            {

                //body.gravityScale = 0.2f;
                canJump = true;
                touchedWall = 2;


            }
            //else
            //{
            //    body.gravityScale = 1;
            //    canJump = false;
            //    Debug.Log(canJump);
            //}
        }

        if (Input.GetAxis("UpArrow") > 0.1f && canJump)
        {
            jump.Play();
            Debug.Log("Jump");
            direction = new Vector2(body.velocity.x, jumpForce);

            //if( touchedWall== 1)
            //{
            //    direction = new Vector2(-40, jumpForce);
            //}
            //else if(touchedWall == 2)
            //{
            //    direction = new Vector2(40, jumpForce);
            //}
            //else if (touchedWall == 0)
            //{
            //    direction = new Vector2(body.velocity.x, jumpForce);
            //}

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
        playerHealth.resetHealth();
    }

    // Update is called once per frame
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
            //footSteps.Play();
            facingLeft = true;
            facingRight = false;
             Animator.transform.Rotate(0, 180, 0);
        }

        if (horizontalMove > 0 && !facingRight)
        {
           // footSteps.Play();
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
            footSteps.volume = 1;
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