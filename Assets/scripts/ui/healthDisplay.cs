using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerHealth playerHealth;
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
        gameObject.transform.localScale = new Vector3(currentHealth, 1f);
    }
}
