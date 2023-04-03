using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI gameOverText;

    public HealthBar healthBar;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {   
        if(currentHealth <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 15;
            healthBar.SetHealth(currentHealth);
        }
    }
}
