using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBoulder : MonoBehaviour
{
    [SerializeField] AudioSource hitGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "woodPlatform")
        {
            hitGround.Play();
        }
    }
}
