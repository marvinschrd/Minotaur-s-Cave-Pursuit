using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCenter : MonoBehaviour
{
    bool key = false;
    SpriteRenderer spriteRenderer;
    Collider2D collider;
    [SerializeField] AudioSource openingDoor;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<Collider2D>();
    }
    void openDoor()
    {
        if(key)
        {
            openingDoor.Play();
            spriteRenderer.enabled = false;
            collider.enabled = false;
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
