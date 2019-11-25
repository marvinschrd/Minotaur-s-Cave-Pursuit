using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowShooter : MonoBehaviour
{

    [SerializeField] GameObject prefabArrow;
    [SerializeField] Transform arrowSpawnPoint;
    private bool canShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private void shoot()
    {
        if (canShoot)
        {
            for (int i = 0; i <= 3; i++)
            {

                GameObject arrow = Instantiate(prefabArrow, arrowSpawnPoint);
                // arrow.gameObject.transform.localScale += new Vector3(1f, 1f, 0);
                arrow.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;
                Debug.Log(arrow.transform);
            }

            canShoot = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "cart")
        {
            Debug.Log("canShoot");
            canShoot = true;
        }
    }

}
