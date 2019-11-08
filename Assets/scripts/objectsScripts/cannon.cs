using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    [SerializeField] GameObject prefabArrows;
    [SerializeField] Transform ArrowsSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Arrow = Instantiate(prefabArrows, ArrowsSpawnPoint);
        Arrow.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
    }

}
