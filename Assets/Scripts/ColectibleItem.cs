using UnityEngine;

public class ColectibleItem : MonoBehaviour
{
    [SerializeField] private CollectibleItemType itemType; // Ссылка на ScriptableObject
    [SerializeField] private bool DestroyObj = true;
    [SerializeField] private int Amount = 1;
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemType != null)
            {
                if (itemType.itemName == "Key")
                {
                    inventory.GetKeys(Amount); // Для ключа
                }
                else if (itemType.itemName == "Coin")
                {
                    inventory.GetCoins(Amount); // Для монеты
                }
            }

            if (DestroyObj)
            {
                Destroy(gameObject); // Уничтожаем предмет
            }

            Debug.Log($"{itemType.itemName} collected");
        }
    }
}