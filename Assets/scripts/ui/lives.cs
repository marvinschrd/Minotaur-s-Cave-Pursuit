using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    [SerializeField] Image life1;
    [SerializeField] Image life2;
    [SerializeField] Image life3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateLives(int life)
    {
        Debug.Log("life =" + life);
        switch (life)
        {
            
            case 3:
                break;
            case 2:
                life3.enabled = false;
                break;
            case 1:
                life2.enabled = false;
                break;
            case 0:
                life1.enabled = false;
                break;
        }
    }
}
