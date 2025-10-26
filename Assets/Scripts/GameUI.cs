using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text healthText;
    public Text orbsText;
    public Text winText;
    
    private PlayerHealth playerHealth;
    private ObjectiveTracker objectiveTracker;
    
    void Start()
    {
        // Find the player and objective tracker in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        
        objectiveTracker = FindObjectOfType<ObjectiveTracker>();
        
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        // Update UI elements
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "Health: " + playerHealth.GetCurrentHealth() + "/" + playerHealth.GetMaxHealth();
        }
        
        if (objectiveTracker != null && orbsText != null)
        {
            orbsText.text = "Orbs: " + objectiveTracker.GetOrbsCollected() + "/" + objectiveTracker.GetTotalOrbs();
        }
    }
    
    public void ShowWinText()
    {
        if (winText != null)
        {
            winText.text = "You Win! All Energy Orbs Collected in Orb Dasher!";
            winText.gameObject.SetActive(true);
        }
    }
}