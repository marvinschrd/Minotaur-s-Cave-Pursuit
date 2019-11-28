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
        currentHealth -= dmg;

        Debug.Log("Current health = " + currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            if (anim != null&& isDead)
            {
                anim.SetBool("destruct", true);
            }
            Destroy(gameObject);
        }
    }

   
}
