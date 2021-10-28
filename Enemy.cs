using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    //Learn about code inheratence
{
    public Animator animator;

    public int maxHealth = 100;
    public GameObject enemy;
    int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start() 
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die() 
    {

        //animator.SetBool("IsDead", true);

        Destroy(enemy, 2);
        //this.enabled = false;
    }
}
