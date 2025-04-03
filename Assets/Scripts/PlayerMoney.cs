// Если честно мне чат гпт помог чутка

using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [Header("Money Info")]
    [SerializeField] private int currentMoney = 500;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI moneyText;

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"{currentMoney}";
        }
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public void SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    public bool CanSpendMoney(int amount)
    {
        return currentMoney >= amount;
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    private void Start()
    {
        UpdateMoneyUI();
    }
}