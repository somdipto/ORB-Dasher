using UnityEngine;

public class SecurityDroneAI : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float detectionRange = 10.0f;  // How far the drone can detect the player
    public int damageOnTouch = 25;  // Damage dealt to player when touched
    public float patrolDistance = 5.0f; // Distance to patrol back and forth
    
    private Transform player;
    private Vector3 startPosition;
    private bool movingRight = true;
    private bool hasTarget = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
    }
    
    void Update()
    {
        // Check if player is within detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= detectionRange)
        {
            hasTarget = true;
            // Follow the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        {
            hasTarget = false;
            // Patrol back and forth
            Patrol();
        }
    }
    
    void Patrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x > startPosition.x + patrolDistance)
            {
                movingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x < startPosition.x - patrolDistance)
            {
                movingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        // If the drone collides with the player, damage the player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageOnTouch);
            }
        }
    }
}