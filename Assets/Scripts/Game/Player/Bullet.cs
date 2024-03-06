using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision) //herhangi bir yere çarpınca fark edilcek
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);//enemy yok eder
        }
       
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x<0 || screenPosition.x>camera.pixelWidth || screenPosition.y<0 || screenPosition.y>camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
