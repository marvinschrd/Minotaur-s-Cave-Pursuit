using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowShooter : MonoBehaviour
{
    [SerializeField] GameObject prefabArrow;
    [SerializeField] Transform arrowSpawnPoint;
    [SerializeField] AudioSource arrowSound;
    [SerializeField] float arrowSpeed = 10;
    bool canShoot = false;
    void Update()
    {
        shoot();
    }
    private void shoot()
    {
        if (canShoot)
        {
            for (int i = 0; i <= 1; i++)
            {
                arrowSound.Play();
                GameObject arrow = Instantiate(prefabArrow, arrowSpawnPoint);
                arrow.GetComponent<Rigidbody2D>().velocity = Vector2.down * arrowSpeed;
            }
            canShoot = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "cart")
        {
            canShoot = true;
        }
    }
}
