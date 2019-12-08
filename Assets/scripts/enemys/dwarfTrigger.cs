using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwarfTrigger : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] escapingDwarf dwarf;
    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dwarf.playerDetected();
        }
    }
}
