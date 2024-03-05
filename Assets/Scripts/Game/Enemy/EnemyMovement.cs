using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rigidbody;
    private PlayerAwarenessController playerAwarenessController;

    private Vector2 targetDirection;
    private float changeDirectionCooldown;  

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;
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
}
