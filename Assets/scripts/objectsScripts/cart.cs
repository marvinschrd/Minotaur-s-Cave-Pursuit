using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour
{

   private Rigidbody2D body;
   private Vector2 direction;
    [SerializeField] float speed = 0;
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
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(body.velocity.y);
        direction = new Vector2(1*speed, body.velocity.y);
        body.velocity = direction;
        //if (body.velocity.y < -0.1f)
        //{
        //    direction = new Vector2(body.velocity.x, body.velocity.y * 1.1f);
        //}
    }

}
