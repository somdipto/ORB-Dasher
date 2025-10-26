using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CombatManager combatManager;
    
    void Start()
    {
        combatManager = GetComponent<CombatManager>();
    }
    
    void Update()
    {
        // Check for attack input (Left Mouse Button or Space)
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            if (combatManager != null)
            {
                combatManager.Attack();
            }
        }
    }
}