using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float timeToFall = 0.05f;
    private float timerToFall = 0f;
    private bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        DelayBeforFalling();
    }
    void DelayBeforFalling()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
    }

}
