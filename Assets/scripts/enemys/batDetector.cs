using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batDetector : MonoBehaviour
{
    [SerializeField] AudioSource squeak;
    bat batScript;
    // Start is called before the first frame update
    void Start()
    {
        batScript = GetComponentInParent<bat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
