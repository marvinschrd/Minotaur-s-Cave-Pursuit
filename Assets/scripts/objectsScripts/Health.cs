using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    float currentHealth;
    bool isDead = false;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem Particle;
    [SerializeField] AudioSource hit;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int dmg)
    {
        if (hit != null)
        {
            hit.Play();
        }
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            isDead = true;
            if (Particle != null)
            {
                Particle.Play();
            }
            anim.SetBool("destruct", true);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
