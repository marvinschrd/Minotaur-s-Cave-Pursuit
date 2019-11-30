using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    [SerializeField] GameObject prefabCannonball;
    [SerializeField] Transform cannonBallSpawnPoint;
    private float fireTimer = 0f;
   [SerializeField] private float fireDuration = 10f;
    private float fireCoolDown = 2.0f;
    private bool canShoot = false;
    private bool coolDownOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
       if(canShoot == true && coolDownOn == false)
        {
            fireTimer = fireDuration;
        GameObject cannonBall = Instantiate(prefabCannonball, cannonBallSpawnPoint);
            Debug.Log(cannonBall.transform.position);
        cannonBall.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
        cannonBall.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
        coolDownOn = true;
        }
        if (coolDownOn == true)
        {
           // Debug.Log("coolDown is on");
            fireTimer -= Time.deltaTime;
           // Debug.Log(fireTimer);
            if(fireTimer <0)
            {
                coolDownOn = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
        canShoot = true;
        }
          
    }

}
