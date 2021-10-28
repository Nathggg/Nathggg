using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {

        if (GetComponent<playerMovement>().isRolling != true)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
        
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
