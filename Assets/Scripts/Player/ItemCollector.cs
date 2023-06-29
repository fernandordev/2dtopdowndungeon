using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int gold_key = 0;
    public int silver_key = 0;
    public int health_pot = 0;

    [SerializeField] private TextMeshProUGUI goldKeyText;
    [SerializeField] private TextMeshProUGUI silverKeyText;

    private PlayerLife playerLife;

    // [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        playerLife = GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoldKey"))
        {
            // collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gold_key++;
            goldKeyText.text = "" + gold_key;
        }

        if (collision.gameObject.CompareTag("SilverKey"))
        {
            // collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            silver_key++;
            silverKeyText.text = "" + silver_key;
        }

        if (collision.gameObject.CompareTag("HealthPot"))
        {
            // collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            playerLife.SetCurrentHealth(1);
        }
    }
}