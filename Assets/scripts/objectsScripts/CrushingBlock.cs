using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBlock : MonoBehaviour
{
    [SerializeField] private int damage = 200;
    [SerializeField] float timeToFall = 0.05f;
    private float timerToFall = 0f;
    private Rigidbody2D body;
    private bool isTriggered = false;
    private void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        TimeBeforeFalling();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
    }
    void TimeBeforeFalling()
    {
        if (isTriggered == true)
        {
            timeToFall -= Time.deltaTime;
            Debug.Log(timeToFall);
            if (timeToFall <= 0)
            {
                body.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
        isTriggered = false;
    }
}
