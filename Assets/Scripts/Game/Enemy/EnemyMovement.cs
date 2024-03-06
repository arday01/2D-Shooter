using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rigidbody;
    private PlayerAwarenessController playerAwarenessController;

    private Vector2 targetDirection;
    private float changeDirectionCooldown;  
    
    [SerializeField] private float screenBorder;
    private Camera camera;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection() //Hedef yönü
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();


    }

    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;
        
        if (changeDirectionCooldown<0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;
            changeDirectionCooldown = Random.Range(1f,5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (playerAwarenessController.AwereOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget() //düşman hedef yönünde dönmesi için
    {

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation =
            Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rigidbody.SetRotation(rotation);
    }

    private void SetVelocity() //Hızı güncellemek için harket
    {
        rigidbody.velocity = transform.up * speed;
    }

    private void HandleEnemyOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position); //ekran nersinde oldunu

        if ((screenPosition.x<screenBorder && targetDirection.x<0)||(screenPosition.x> camera.pixelWidth-screenBorder && targetDirection.x>0)) //ekran solunda sağında çıkarsa demek
        {
            targetDirection = new Vector2(-targetDirection.x, targetDirection.y);
        }
        
        if ((screenPosition.y<screenBorder && targetDirection.y<0)||(screenPosition.y> camera.pixelHeight-screenBorder && targetDirection.y>0)) //ekran YUKAR AŞAĞI çıkarsa demek
        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
        }
    }
}
