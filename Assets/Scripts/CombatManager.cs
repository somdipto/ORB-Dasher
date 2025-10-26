using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Combat Settings")]
    public float attackRange = 3f;
    public float attackDamage = 25f;
    public float attackCooldown = 1f;
    
    [Header("Effects")]
    public GameObject attackEffect;
    public AudioClip attackSound;
    
    private Camera playerCamera;
    private AudioSource audioSource;
    private float lastAttackTime;
    
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            PerformAttack();
        }
    }
    
    void PerformAttack()
    {
        lastAttackTime = Time.time;
        
        // Play attack sound
        if (audioSource != null && attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
        
        // Raycast from camera center
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, attackRange))
        {
            // Check if we hit an enemy
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                
                // Spawn attack effect at hit point
                if (attackEffect != null)
                {
                    Instantiate(attackEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (playerCamera != null)
        {
            Gizmos.color = Color.red;
            Vector3 rayStart = playerCamera.transform.position;
            Vector3 rayDirection = playerCamera.transform.forward * attackRange;
            Gizmos.DrawRay(rayStart, rayDirection);
        }
    }
}
