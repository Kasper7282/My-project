using UnityEngine;
using UnityEngine.EventSystems;

public class PoisonItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int damageAmount = 20;  // Урон от яда
    private Player playerReference;
    private PlayerMoney playerMoneyReference;

    // Ссылка на PurchaseItem, откуда будем брать цену товара
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

            if (playerMoneyReference.CanSpendMoney(itemCost))
            {
                playerMoneyReference.SpendMoney(itemCost);
                playerReference.TakeDamage(damageAmount);
                Debug.Log($"Poison applied for {damageAmount} damage. Remaining money: {playerMoneyReference.GetCurrentMoney()}");
            }
            else
            {
                Debug.Log("Not enough money to use poison!");
            }
        }
        else
        {
            Debug.LogError("Cannot use item: Player, PlayerMoney, or PurchaseItem reference not found!");
        }
    }
}