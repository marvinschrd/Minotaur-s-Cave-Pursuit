using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batDetector : MonoBehaviour
{
    [SerializeField] AudioSource squeak;
    bat batScript;
    void Start()
    {
        batScript = GetComponentInParent<bat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            batScript.playerDetected(collision.transform.position);
            squeak.Play();
        }
    }
}
