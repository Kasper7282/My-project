using UnityEngine;
using UnityEngine.EventSystems;

public class FoodItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int healAmount = 20;
    [SerializeField] private PurchaseItem purchaseItemReference;

    private Player playerReference;
    private PlayerMoney playerMoneyReference;

    private void Start()
    {
        playerReference = FindObjectOfType<Player>();
        playerMoneyReference = FindObjectOfType<PlayerMoney>();

        if (playerReference == null)
            Debug.LogError("Player not found in the scene!");

        if (playerMoneyReference == null)
            Debug.LogError("PlayerMoney not found in the scene!");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }

    public void UseItem()
    {
        if (playerReference == null || playerMoneyReference == null)
        {
            Debug.LogError("Cannot use item: Missing Player or PlayerMoney reference!");
            return;
        }

        // Если не задан purchaseItemReference — просто хил без проверок
        if (purchaseItemReference == null)
        {
            playerReference.Heal(healAmount);
            Debug.Log($"Healed for {healAmount}. (No price check)");
            return;
        }

        int itemCost = purchaseItemReference.GetItemPrice();

        if (playerMoneyReference.CanSpendMoney(itemCost))
        {
            playerReference.Heal(healAmount);
            Debug.Log($"Healed for {healAmount}. Money check passed.");
        }
        else
        {
            Debug.Log("Not enough money to use item!");
        }
    }
}