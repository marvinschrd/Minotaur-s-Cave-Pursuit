using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapingDwarf : MonoBehaviour
{

    Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }

}
