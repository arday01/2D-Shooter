using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    private InvincibilityController invincibilityController;
    
    [SerializeField]private float invincibilityDuration;
    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(invincibilityDuration);
    }
    
}
