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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        if (hit != null)
        {
            hit.Play();
        }
        currentHealth -= dmg;

        Debug.Log("Current health = " + currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            //if (anim != null&& isDead)
            //{
            //}
            if (Particle != null)
            {
                Particle.Play();
            }
            anim.SetBool("destruct", true);
            //Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Debug.Log("destroy");
        Destroy(gameObject);
    }



}
