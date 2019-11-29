using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float timeToFall = 0.05f;
    private float timerToFall = 0f;
    [SerializeField] float timeToRespawn = 1f;
    private float timerToRespawn = 0f;
    private bool isTriggered = false;
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //DelayBeforFalling();
        switch(state)
        {
            case State.IDLE:
                //Debug.Log("idle");
                timerToFall = timeToFall;
                timerToRespawn = timeToRespawn;
                body.bodyType = RigidbodyType2D.Static;
                break;
            case State.WAITING_TO_FALL:
                Debug.Log("waiting");
                timerToFall -= Time.deltaTime;
                if(timerToFall <= 0)
                {
                    state = State.FALLING;
                }
                break;
            case State.FALLING:
                Debug.Log("falling");
                body.bodyType = RigidbodyType2D.Dynamic;
                timerToRespawn -= Time.deltaTime;
                Debug.Log(timerToFall);
                if (timerToRespawn <= 0)
                {
                    state = State.RESPAWN;
                }
                break;
            case State.RESPAWN:
                Debug.Log("respawn");
                body.position = originalPosition;
                state = State.IDLE;
                break;
        }
    }
    //void DelayBeforFalling()
    //{
    //    if (isTriggered == true)
    //    {
           
    //        timeToFall -= Time.deltaTime;
    //        //Debug.Log(timeToFall);
    //        if (timeToFall <= 0)
    //        {
    //            body.bodyType = RigidbodyType2D.Dynamic;
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //isTriggered = true;
        state = State.WAITING_TO_FALL;
    }

    enum State
    {
        IDLE,
        WAITING_TO_FALL,
        FALLING,
        RESPAWN
    }
    State state = State.IDLE;

}
