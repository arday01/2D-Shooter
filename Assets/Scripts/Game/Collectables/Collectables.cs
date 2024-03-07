using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private ICollectableBehaviour collectableBehaviour;

    private void Awake()
    {
        collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pLayer = collision.GetComponent<PlayerMovement>();
        if (pLayer!=null)
        {
            collectableBehaviour.OnCollected(pLayer.gameObject);
            Destroy(gameObject);
        }
    }
}
