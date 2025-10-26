using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    private bool collected = false;
    
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collected the orb
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            
            // Find the ObjectiveTracker in the scene and report the collection
            ObjectiveTracker tracker = FindObjectOfType<ObjectiveTracker>();
            if (tracker != null)
            {
                tracker.CollectEnergyOrb();
            }
            
            // Play collection effect
            Debug.Log("Energy Orb collected!");
            
            // Destroy the orb
            Destroy(gameObject);
        }
    }
}