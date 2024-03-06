
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D rigidbody;

    [SerializeField]private float rotationSpeed;

    [SerializeField] private float screenBorder;
        
    private Vector2 movementInpute;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    

    private Camera camera;

    private Animator animator;


    public static PlayerMovement Instance;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Instance = this;
        camera = Camera.main;
        animator = GetComponent<Animator>();
        SetAnimation();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionInput();
        SetAnimation();
    }

    private void SetAnimation()
    {
        bool isMoving = movementInpute != Vector2.zero;
        animator.SetBool("IsMoving",isMoving);
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput,movementInpute,
            ref movementInputSmoothVelocity, 0.1f); //harketi yumuşatık

        rigidbody.velocity = smoothedMovementInput*speed; //hız ve düzgün harket ekledik
        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position); //ekran nersinde oldunu

        if ((screenPosition.x<screenBorder && rigidbody.velocity.x<0)||(screenPosition.x> camera.pixelWidth-screenBorder && rigidbody.velocity.x>0)) //ekran solunda sağında çıkarsa demek
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        
        if ((screenPosition.y<screenBorder && rigidbody.velocity.y<0)||(screenPosition.y> camera.pixelHeight-screenBorder && rigidbody.velocity.y>0)) //ekran YUKAR AŞAĞI çıkarsa demek
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        }
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

