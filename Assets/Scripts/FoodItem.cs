// Слава чату гпт без него у меня бы мозг взорвался от починки багов
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int healAmount = 20;  // Количество здоровья для восстановления
    private Player playerReference;
    private PlayerMoney playerMoneyReference;

    // Ссылка на скрипт PurchaseItem, чтобы считывать цену
    private PurchaseItem purchaseItemReference;

    private void Start()
    {
        playerReference = FindObjectOfType<Player>();
        playerMoneyReference = FindObjectOfType<PlayerMoney>();
        purchaseItemReference = FindObjectOfType<PurchaseItem>();  // Получаем ссылку на PurchaseItem

        if (playerReference == null)
        {
            Debug.LogError("Player not found in the scene!");
        }

        if (playerMoneyReference == null)
        {
            Debug.LogError("PlayerMoney not found in the scene!");
        }

        if (purchaseItemReference == null)
        {
            Debug.LogError("PurchaseItem not found in the scene!");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }

    public void UseItem()
    {
        if (playerReference != null && playerMoneyReference != null && purchaseItemReference != null)
        {
            int itemCost = purchaseItemReference.GetItemPrice();  // Получаем цену товара из PurchaseItem

            // Проверяем, хватает ли денег
            if (playerMoneyReference.CanSpendMoney(itemCost))
            {
                playerMoneyReference.SpendMoney(itemCost);  // Списываем деньги
                playerReference.Heal(healAmount);  // Восстанавливаем здоровье
                Debug.Log($"Healed for {healAmount}. Remaining money: {playerMoneyReference.GetCurrentMoney()}");
            }
            else
            {
                Debug.Log("Not enough money to use item!");
            }
        }
        else
        {
            Debug.LogError("Cannot use item: Player, PlayerMoney, or PurchaseItem reference not found!");
        }
    }
}
