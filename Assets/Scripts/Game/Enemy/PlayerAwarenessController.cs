using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    
    public bool AwereOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer{ get; private set; }

    [SerializeField]private float playerAwarenessDistance;

    private Transform player; // karkter nerde olduna bakcak

    private void Awake()
    {
        
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update() 
    {
        //oyuncunun menzilde mi değil mi 
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        
        if (enemyToPlayerVector.magnitude<=playerAwarenessDistance)
        {
            AwereOfPlayer = true;
        }
        else
        {
            AwereOfPlayer = false;
        }
    }
}
