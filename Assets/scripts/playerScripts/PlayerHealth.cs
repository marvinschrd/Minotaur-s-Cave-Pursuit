using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerController player;
    [SerializeField]
    float maxHealth;
    [SerializeField] Animator animator;
    float currentHealth;
    float hurtTimer = 1f;
    float hurtTime = 0.5f;
    bool startTimer = false;
    bool hurted = false;
    

    // Start is called before the first frame update
    void Start()
    {
       currentHealth = maxHealth;
       PlayerController playerController = transform.gameObject.GetComponent<PlayerController>();
       player = playerController;
        animator.SetBool("isHurt", false);
        hurtTimer = 0f;
    }

    // Update is called once per frame

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
       
        animator.SetBool("isHurt",true);
        Debug.Log("Current health = " + currentHealth);
        hurtTimer = hurtTime;

        if (currentHealth <= 0)
        {
            
            player.Respawn();   
            
        }

    }
    void Update()
    {
        hurtTimer -= Time.deltaTime;
        if (hurtTimer <= 0f)
        {
            animator.SetBool("isHurt", false);
        }
    }
    public void TakeHealth(int health)
    {
        currentHealth += health;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}