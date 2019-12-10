using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
   public void setHealth(float currentHealth,float maxHealth)
    {
        currentHealth = currentHealth / maxHealth;
        transform.localScale = new Vector2(currentHealth, 1f);
        if(currentHealth <= 0)
        {
            transform.localScale = new Vector2(0f, 1f);
        }
        if (currentHealth >=1)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
