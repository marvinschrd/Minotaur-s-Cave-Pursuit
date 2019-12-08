using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void setHealth(float currentHealth,float maxHealth)
    {
        currentHealth = currentHealth / maxHealth;
        Debug.Log("health =" +currentHealth);
       transform.localScale = new Vector2(currentHealth, 1f);
        if(currentHealth <= 0)
        {
            transform.localScale = new Vector2(0, 1f);
        }
        //transform.localScale = 
    }
}
