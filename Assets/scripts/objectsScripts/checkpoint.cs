using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    private Vector2 checkPointPosition;
    private void Start()
    {
        checkPointPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("okay");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.checkpointReached(checkPointPosition);
            
        }
    }
}
