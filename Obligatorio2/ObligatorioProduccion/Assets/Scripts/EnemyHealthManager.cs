using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Animator animator;

    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0){
            animator.SetBool("IsDead", true);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
