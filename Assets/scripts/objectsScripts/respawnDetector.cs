using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnDetector : MonoBehaviour
{
    int damage = 1000;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            playerController.Respawn();
        }
    }
}
