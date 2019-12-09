using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health Health = collision.gameObject.GetComponent<Health>();
            Health.TakeDamage(damage);
        }
    }
}
