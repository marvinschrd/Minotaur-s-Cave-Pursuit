using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    [SerializeField] GameObject prefabCannonball;
    [SerializeField] Transform cannonBallSpawnPoint;
    float fireTimer = 0f;
    [SerializeField] private float fireDuration = 10f;
    float fireCoolDown = 2.0f;
    bool canShoot = false;
    bool coolDownOn = false;
    [SerializeField] ParticleSystem cannonParticle;
    [SerializeField] AudioSource cannonSound;
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
       if(canShoot == true && coolDownOn == false)
        {
           fireTimer = fireDuration;
           cannonSound.Play();
           GameObject cannonBall = Instantiate(prefabCannonball, cannonBallSpawnPoint);
           cannonParticle.Play();
           cannonBall.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
           cannonBall.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
           coolDownOn = true;
        }
        if (coolDownOn == true)
        {
            fireTimer -= Time.deltaTime;
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
