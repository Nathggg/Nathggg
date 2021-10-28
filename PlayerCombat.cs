﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 15;
    
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //public bool balls;
    void Update()
    {
        if(Time.time >= nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) 
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}