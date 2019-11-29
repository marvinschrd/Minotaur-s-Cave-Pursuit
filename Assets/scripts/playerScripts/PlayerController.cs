using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
   [SerializeField] public Animator Animator;
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

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        body = GetComponent<Rigidbody2D>();
        
        

        if (body != null)
        {
            Debug.Log("Player's body founded!");
        }
        else
        {
            Debug.Log("No player body");
        }
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

        if (Input.GetAxis("Jump") > 0.1f && canJump)
        {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        Animator.SetFloat("speed",Mathf.Abs( Input.GetAxis("Horizontal")*speed));
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
        Animator.SetFloat("damage", -1);
        
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.down * raycastJumpLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.right * raycastJumpLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.left * raycastJumpLength);


    }
   
}