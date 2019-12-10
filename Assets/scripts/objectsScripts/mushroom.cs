using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    [SerializeField]int heal = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.TakeHealth(heal);
            Destroy(gameObject);
        }
    }
}
