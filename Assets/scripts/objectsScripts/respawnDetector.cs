using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnDetector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("detected");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.Respawn();
        }
    }
}
