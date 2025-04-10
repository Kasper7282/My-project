using System;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keysCollectedText;
    [SerializeField] private TextMeshProUGUI coinsCollectedText;
    private int KeysCollected;
    private int coinsCollected;
    public AudioClip KeypickupSound;
    public AudioClip AlertSound;
    private AudioSource audioSource;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void UpdateUI()
    {
        if (keysCollectedText != null)
        {
            keysCollectedText.text = $"{KeysCollected}";
        }
        if (coinsCollectedText != null)
        {
            coinsCollectedText.text = $"{coinsCollected}";
        }
    }
    public void GetKeys(int amount)
    {
        if (KeysCollected + amount >= 0)
        {   
            KeysCollected += amount;
            UpdateUI();
            Debug.Log($"GotKey {amount}");
            if (KeypickupSound != null && player != null)
            {
                AudioSource.PlayClipAtPoint(KeypickupSound, player.transform.position);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(AlertSound, player.transform.position);
        }
    }
    public void GetCoins(int amount)
    {
        if (coinsCollected + amount >= 0)
        {   
            coinsCollected += amount;
            UpdateUI();
            Debug.Log($"GotCoins {amount}");
            if (KeypickupSound != null && player != null)
            {
                AudioSource.PlayClipAtPoint(KeypickupSound, player.transform.position);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(AlertSound, player.transform.position);
        }
    }

}
