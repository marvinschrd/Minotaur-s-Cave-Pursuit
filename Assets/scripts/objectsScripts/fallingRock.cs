using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingRock : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] int damage;
    [SerializeField] float timeToFall;
    float timerToFall;
    bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered)
        {
            timerToFall -= Time.deltaTime;
            if(timerToFall <=0)
            {
                body.bodyType = RigidbodyType2D.Dynamic;
            }
               
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            timerToFall = timeToFall;
            isTriggered = true;
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
