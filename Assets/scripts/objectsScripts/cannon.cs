using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField] GameObject prefabCannonball;
    [SerializeField] Transform cannonBallSpawnPoint;
    float fireTimer = 0f;
    [SerializeField]float fireCoolDown = 2.0f;
    [SerializeField] ParticleSystem cannonParticle;
    [SerializeField] AudioSource cannonSound;
    enum State
    {
        IDLE,
        SHOOT,
        COOLDOWN
    }
    State state = State.IDLE;
    void Update()
    {
        switch (state)
        {
            case State.IDLE:

                break;
            case State.SHOOT:
                fireTimer = fireCoolDown;
                cannonSound.Play();
                GameObject cannonBall = Instantiate(prefabCannonball, cannonBallSpawnPoint);
                cannonParticle.Play();
                cannonBall.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
                cannonBall.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
                state = State.COOLDOWN;
                break;
            case State.COOLDOWN:
                fireTimer -= Time.deltaTime;
                if(fireTimer<=0)
                {
                    state = State.SHOOT;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            state = State.SHOOT;
        } 
    }
}
