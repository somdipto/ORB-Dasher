using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    [Header("Orb Settings")]
    public float rotationSpeed = 50f;
    public float bobSpeed = 2f;
    public float bobHeight = 0.5f;
    public int orbValue = 10;
    
    [Header("Effects")]
    public GameObject collectEffect;
    public AudioClip collectSound;
    
    private Vector3 startPosition;
    private AudioSource audioSource;
    
    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // Rotate the orb
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
        // Bob up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectOrb(other.gameObject);
        }
    }
    
    void CollectOrb(GameObject player)
    {
        // Add to player's score/energy
        ObjectiveTracker tracker = FindObjectOfType<ObjectiveTracker>();
        if (tracker != null)
        {
            tracker.CollectOrb();
        }
        
        // Play collection effect
        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }
        
        // Play sound
        if (audioSource != null && collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
        }
        
        // Destroy the orb
        Destroy(gameObject);
    }
}
