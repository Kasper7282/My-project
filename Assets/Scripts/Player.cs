using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 50;
    
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider healthSlider;

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
        
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
    
    public void Heal(int healAmount)
    {
        // Add healing amount
        currentHealth += healAmount;
        
        // Make sure we don't exceed max health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        
        Debug.Log($"Healed for {healAmount}. Current health: {currentHealth}/{maxHealth}");
        UpdateHealthUI();
    
    }
    
    private void Start()
    {
        UpdateHealthUI();
    }
}