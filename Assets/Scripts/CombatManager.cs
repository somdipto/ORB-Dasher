using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public int attackDamage = 25;
    public float attackRange = 2.0f;
    public float attackRadius = 1.0f;
    public float attackRate = 1.0f;
    
    private float nextAttackTime = 0f;
    
    public void PerformAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            // Find enemies in attack range
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRadius);
            
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    // Apply damage to the enemy
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(attackDamage);
                    }
                }
            }
            
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    
    // This method allows external scripts to trigger an attack
    public void Attack()
    {
        PerformAttack();
    }
    
    // Visualize attack range in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}