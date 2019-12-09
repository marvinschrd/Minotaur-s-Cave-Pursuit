using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    PlayerController player;
    [SerializeField]
    float maxHealth;
    [SerializeField] int lives = 3;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource growl;
    [SerializeField] AudioSource takeHealth;
    [SerializeField] healthDisplay healtBar;
    [SerializeField] lives life;
    float currentHealth;
    float hurtTimer = 1f;
    float hurtTime = 0.5f;
    bool startTimer = false;
    bool hurted = false;
    void Start()
    {
        currentHealth = maxHealth;
        PlayerController playerController = transform.gameObject.GetComponent<PlayerController>();
        player = playerController;
        animator.SetBool("isHurt", false);
        hurtTimer = 0f;
    }
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healtBar.setHealth(currentHealth, maxHealth);
        growl.Play();
        animator.SetBool("isHurt", true);
        Debug.Log("Current health = " + currentHealth);
        hurtTimer = hurtTime;
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    public void resetHealth()
    {
        currentHealth = maxHealth;
        healtBar.setHealth(currentHealth, maxHealth);
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
        takeHealth.Play();
        currentHealth += health;
        healtBar.setHealth(currentHealth, maxHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
public void loseLife()
    {
        lives--;
        life.updateLives(lives);
    }
}