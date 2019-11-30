using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    private float attackTimer = 0f;
    private float attackCoolDown = 0.3f;
    private float attackDamage = 0f;

    public Collider2D attackTrigger;

    [SerializeField] public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetButtonDown("attack")&& !attacking)
            {
                //Debug.Log("yes");
            attacking = true;
              
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;

            }
            //if (Input.GetButtonUp("Fire1"))
            //{
            //    Debug.Log("yes");
            //    Animator.SetBool("isFighting", false);
            //}
            if(attacking == true)
            {

                if(attackTimer > 0)
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

