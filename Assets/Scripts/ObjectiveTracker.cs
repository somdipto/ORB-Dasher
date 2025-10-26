using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTracker : MonoBehaviour
{
    [Header("Objectives")]
    public int totalOrbs = 10;
    public int orbsCollected = 0;
    
    [Header("UI")]
    public Text orbCountText;
    public Text objectiveText;
    public GameObject victoryPanel;
    
    void Start()
    {
        UpdateUI();
    }
    
    public void CollectOrb()
    {
        orbsCollected++;
        UpdateUI();
        
        if (orbsCollected >= totalOrbs)
        {
            CompleteObjective();
        }
    }
    
    void UpdateUI()
    {
        if (orbCountText != null)
        {
            orbCountText.text = $"Orbs: {orbsCollected}/{totalOrbs}";
        }
        
        if (objectiveText != null)
        {
            if (orbsCollected < totalOrbs)
            {
                objectiveText.text = $"Collect {totalOrbs - orbsCollected} more energy orbs";
            }
            else
            {
                objectiveText.text = "All orbs collected! Mission Complete!";
            }
        }
    }
    
    void CompleteObjective()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
        
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public float GetCompletionPercentage()
    {
        return (float)orbsCollected / totalOrbs;
    }
}
