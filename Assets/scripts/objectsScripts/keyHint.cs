using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField]SpriteRenderer spriteRendererInBubble;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        spriteRendererInBubble.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = true;
            spriteRendererInBubble.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.enabled = false;
        spriteRendererInBubble.enabled = false;
    }
}
