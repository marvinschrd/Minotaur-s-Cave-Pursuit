using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    [SerializeField] int damage = 20;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject);
        if(other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
            Destroy(gameObject);
    }
}
