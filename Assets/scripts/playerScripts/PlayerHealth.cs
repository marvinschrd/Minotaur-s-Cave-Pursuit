using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    float maxHealth;
    [SerializeField] Animator animator;
    float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("damage", 0);
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        //animator.SetFloat("damage", dmg);
        Debug.Log("Current health = " + currentHealth);
       
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            //Destroy(gameObject);
        }
    }
}