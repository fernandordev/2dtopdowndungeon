using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private int maxHealth = 5;
    public int currentHealth;

    public GameObject gameOver;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }

        if (collision.gameObject.CompareTag("Flag"))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Damage();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Damage();
        }
    }

    public void SetCurrentHealth(int health)
    {
        healthBar.SetHealth(currentHealth + health);
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        this.GetComponent<PlayerController>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetTrigger("death");
        Invoke("ShowGameOver", 1f);
    }

    private void Damage()
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(2);
    }
}