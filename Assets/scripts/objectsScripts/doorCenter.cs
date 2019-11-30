using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCenter : MonoBehaviour
{
    bool key = false;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
    }

    void openDoor()
    {
        if(key)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            key = playerController.Usekey();
            Debug.Log("key" + key);
        }
    }
}
