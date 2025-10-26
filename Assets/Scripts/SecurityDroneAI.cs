using UnityEngine;
using UnityEngine.AI;

public class SecurityDroneAI : MonoBehaviour
{
    [Header("AI Settings")]
    public float detectionRange = 10f;
    public float attackRange = 3f;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float attackDamage = 20f;
    public float attackCooldown = 2f;
    
    [Header("Patrol")]
    public Transform[] patrolPoints;
    
    private NavMeshAgent agent;
    private Transform player;
    private int currentPatrolIndex = 0;
    private float lastAttackTime;
    private bool playerInRange = false;
    
    public enum DroneState { Patrolling, Chasing, Attacking }
    public DroneState currentState = DroneState.Patrolling;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[0].position);
        }
    }
    
    void Update()
    {
        if (player == null) return;
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        switch (currentState)
        {
            case DroneState.Patrolling:
                Patrol();
                if (distanceToPlayer <= detectionRange)
                {
                    currentState = DroneState.Chasing;
                    agent.speed = chaseSpeed;
                }
                break;
                
            case DroneState.Chasing:
                ChasePlayer();
                if (distanceToPlayer <= attackRange)
                {
                    currentState = DroneState.Attacking;
                }
                else if (distanceToPlayer > detectionRange * 1.5f)
                {
                    currentState = DroneState.Patrolling;
                    agent.speed = patrolSpeed;
                }
                break;
                
            case DroneState.Attacking:
                AttackPlayer();
                if (distanceToPlayer > attackRange)
                {
                    currentState = DroneState.Chasing;
                }
                break;
        }
    }
    
    void Patrol()
    {
        if (patrolPoints.Length == 0) return;
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }
    
    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    
    void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
