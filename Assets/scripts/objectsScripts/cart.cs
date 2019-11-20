using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour
{

   private Rigidbody2D body;
   private Vector2 direction;
   private bool isTriggered = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isTriggered)
        {
            
           if(body.velocity.magnitude <1)
            {
                Debug.Log(body.velocity.y);
                direction = new Vector2(1, body.velocity.y);
                body.velocity = direction;
            }

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
        
    }

}
