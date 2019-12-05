using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCenter : MonoBehaviour
{
    bool key = false;
    SpriteRenderer spriteRenderer;
    Collider2D collider;
    [SerializeField] AudioSource openingDoor;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //openDoor();
    }

    void openDoor()
    {
        if(key)
        {
            openingDoor.Play();
            spriteRenderer.enabled = false;
            collider.enabled = false;
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            key = playerController.Usekey();
            openDoor();
            Debug.Log("key" + key);
        }
    }
}
