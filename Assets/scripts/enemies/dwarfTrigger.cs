using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwarfTrigger : MonoBehaviour
{
     [SerializeField] escapingDwarf dwarf;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dwarf.playerDetected();
        }
    }
}
