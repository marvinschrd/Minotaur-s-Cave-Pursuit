using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapingDwarf : MonoBehaviour
{

    Rigidbody2D body;
   [SerializeField] Animator animator;
    [SerializeField] AudioSource cry;
    Vector2 direction;
   [SerializeField] float speed;
    bool run = false;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        //switch(state)
        //{
        //    case State.IDLE:
        //        Debug.Log("idle");
        //        break;
        //    case State.SURPRISED:
        //        if (!run)
        //        {
        //            Debug.Log("srprise");
        //            animator.transform.Rotate(0, 180, 0);
        //            animator.SetBool("playerOnSight", true);
        //        }
        //        break;
        //    case State.RUN:
        //        run = true;
        //        Debug.Log("run");
        //        animator.transform.Rotate(0, 180, 0);
        //        animator.SetBool("startRunning", true);
        //        direction = new Vector2(1 * speed, 0);
        //        break;
        //}


        if (run)
        {
            direction = new Vector2(1 * speed, 0);
        }
    }

    enum State
    {
        IDLE,
        SURPRISED,
        RUN
    }
    State state = State.IDLE;

    private void FixedUpdate()
    {
        body.velocity = direction;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        cry.Play();
    //        animator.SetBool("playerOnSight", true);
    //        //animator.transform.Rotate(0, 180, 0);
    //        state = State.SURPRISED;
    //        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
    //        playerController.freeze();
    //    }
    //}

    public void playerDetected()
    {
        Debug.Log("detected");
        cry.Play();
        animator.SetBool("playerOnSight", true);
        //animator.transform.Rotate(0, 180, 0);
        state = State.SURPRISED;
        player.freeze();
    }


    void startRunning()
    {
        animator.transform.Rotate(0, 180, 0);
        animator.SetBool("startRunning", true);
        run = true;
        state = State.RUN;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
