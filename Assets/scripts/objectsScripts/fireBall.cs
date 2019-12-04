using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    [SerializeField] int damage = 20;
    [SerializeField] Animator anim;
    // Start is called before the first frame update

    public void Destroy()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
        anim.SetBool("explode", true);

    }
}
