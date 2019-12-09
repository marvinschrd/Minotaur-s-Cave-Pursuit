using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool attacking = false;
    float attackTimer = 0f;
    float attackCoolDown = 0.3f;
    float attackDamage = 0f;
    [SerializeField] AudioSource attackSwing;
    public Collider2D attackTrigger;
    [SerializeField] public Animator Animator;
    void Start()
    {
        attackTrigger.enabled = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("attack") && !attacking)
        {
            attackSwing.Play();
            attacking = true;
            attackTimer = attackCoolDown;
            attackTrigger.enabled = true;
        }
        if (attacking == true)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        Animator.SetBool("isFighting", attacking);
    }
}

