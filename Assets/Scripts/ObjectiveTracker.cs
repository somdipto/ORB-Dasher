using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveTracker : MonoBehaviour
{
    [System.Serializable]
    public class Objective
    {
        public string description;
        public bool isCompleted;
    }
    
    public Objective[] objectives;
    private int orbsCollected = 0;
    private int totalOrbs = 3; // As specified in the requirements
    
    void Start()
    {
        // Initialize objectives - we expect one objective: "Collect 3 Energy Orbs"
        if (objectives.Length == 0)
        {
            objectives = new Objective[1];
            objectives[0].description = "Collect 3 Energy Orbs for Orb Dasher";
            objectives[0].isCompleted = false;
        }
    }
    
    public void CompleteObjective(int index)
    {
        if (index >= 0 && index < objectives.Length)
        {
            objectives[index].isCompleted = true;
            CheckWinCondition();
        }
    }
    
    public void CollectEnergyOrb()
    {
        orbsCollected++;
        
        // Check if all orbs have been collected
        if (orbsCollected >= totalOrbs)
        {
            CompleteObjective(0); // Complete the first (and expected only) objective
        }
    }
    
    private void CheckWinCondition()
    {
        bool allCompleted = true;
        foreach (Objective obj in objectives)
        {
            if (!obj.isCompleted)
            {
                allCompleted = false;
                break;
            }
        }
        
        if (allCompleted)
        {
            WinGame();
        }
    }
    
    private void WinGame()
    {
        Debug.Log("You collected all Energy Orbs in Orb Dasher! You win!");
        
        // Call UI to show win message
        GameUI gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
        {
            gameUI.ShowWinText();
        }
    }
    
    public int GetOrbsCollected()
    {
        return orbsCollected;
    }
    
    public int GetTotalOrbs()
    {
        return totalOrbs;
    }
}