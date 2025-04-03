    using UnityEngine;
    using UnityEngine.EventSystems;
    using TMPro;

    public class PurchaseItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int itemPrice = 100;  // Цена товара
        
        public int GetItemPrice()  // Метод для получения цены
        {
            return itemPrice;
        }
        
        private PlayerMoney playerMoneyReference;
        
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI priceText;  // Для отображения цены в UI

        private void Start()
        {
            playerMoneyReference = FindObjectOfType<PlayerMoney>();

            if (playerMoneyReference == null)
            {
                Debug.LogError("PlayerMoney not found in the scene!");
            }

            // Выводим цену товара в UI
            if (priceText != null)
            {
                priceText.text = $"{itemPrice}";
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PurchaseItemAction();
        }

        public void PurchaseItemAction()
        {
            if (playerMoneyReference != null)
            {
                // Проверяем, хватает ли денег у игрока
                if (playerMoneyReference.CanSpendMoney(itemPrice))
                {
                    playerMoneyReference.SpendMoney(itemPrice);
                    Debug.Log($"Purchased item for {itemPrice} money.");
                }
                else
                {
                    Debug.Log("Not enough money to purchase item.");
                }
            }
            else
            {
                Debug.LogError("Cannot use item: PlayerMoney reference not found!");
            }
        }
    }