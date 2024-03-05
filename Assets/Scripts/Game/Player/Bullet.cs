using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //herhangi bir yere çarpınca fark edilcek
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);//enemy yok eder
        }
       
    }
}
