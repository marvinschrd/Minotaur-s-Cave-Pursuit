using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDropper : MonoBehaviour
{
    [SerializeField] GameObject prefabRock;
    [SerializeField] Transform RocksSpawnPoint;
   
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
       
        for (int i = 0; i <= 10; i++)
        {
            GameObject rock = Instantiate(prefabRock,RocksSpawnPoint);
        }
    }

}
