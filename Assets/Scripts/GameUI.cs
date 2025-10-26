using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    
    [Header("Game UI")]
    public Text healthText;
    public Text orbCountText;
    public Text objectiveText;
    public Slider healthBar;
    
    [Header("Menu Buttons")]
    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;
    
    private bool isPaused = false;
    private PlayerHealth playerHealth;
    private ObjectiveTracker objectiveTracker;
    
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        objectiveTracker = FindObjectOfType<ObjectiveTracker>();
        
        // Setup button listeners
        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeGame);
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);
    }
    
    void Update()
    {
        // Handle pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
        
        UpdateUI();
    }
    
    void UpdateUI()
    {
        // Update health display
        if (playerHealth != null)
        {
            if (healthText != null)
                healthText.text = $"Health: {playerHealth.currentHealth:F0}";
            if (healthBar != null)
                healthBar.value = playerHealth.currentHealth / playerHealth.maxHealth;
        }
        
        // Update objective display
        if (objectiveTracker != null)
        {
            if (orbCountText != null)
                orbCountText.text = $"Orbs: {objectiveTracker.orbsCollected}/{objectiveTracker.totalOrbs}";
        }
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
