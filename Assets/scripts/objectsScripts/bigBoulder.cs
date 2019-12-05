using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBoulder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource hitGround;
   
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "woodPlatform")
        {
            hitGround.Play();
        }
    }
    
}
