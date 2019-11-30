using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]PlayerController pplayerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pplayerController.TakeKey();
            Destroy(gameObject);

        }
    }
}
