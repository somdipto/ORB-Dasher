using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    void Start()
    {
        // This script ensures the player has all required components
        // It will be removed after setup to avoid interfering with gameplay
        AddMissingComponents();
        
        // Destroy this setup script after execution
        Destroy(this);
    }
    
    void AddMissingComponents()
    {
        // Add CombatManager if not present
        if (GetComponent<CombatManager>() == null)
        {
            gameObject.AddComponent<CombatManager>();
        }
        
        // Ensure the player has a tag
        if (tag != "Player")
        {
            tag = "Player";
        }
    }
}