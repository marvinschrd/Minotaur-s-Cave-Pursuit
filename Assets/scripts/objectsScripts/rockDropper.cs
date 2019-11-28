﻿using System.Collections;
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
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i <= 3; i++)
            {
                GameObject rock = Instantiate(prefabRock, RocksSpawnPoint);
                rock.gameObject.transform.localScale += new Vector3(8f, 8f, 0);
            }
        }
    }

}
