using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D rigidbody;

    [SerializeField]private float rotationSpeed;
    
    private Vector2 movementInpute;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;


    public static PlayerMovement Instance;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionInput();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput,movementInpute,
            ref movementInputSmoothVelocity, 0.1f); //harketi yumuşatık

        rigidbody.velocity = smoothedMovementInput*speed; //hız ve düzgün harket ekledik
    }

    private void RotateInDirectionInput() //karket yöne göre bakması
    {
        if (movementInpute!=Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward,smoothedMovementInput);
            Quaternion rotaiton = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
            rigidbody.MoveRotation(rotaiton);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInpute=inputValue.Get<Vector2>();//hareket ettirdik
    }
}

