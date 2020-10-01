using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        if(currentHealth <= 0){
            if (!gameObject.GetComponent<BodyController>().isInputEnabled)
                gameObject.GetComponent<RespawnController>().Respawn();
            else
                gameObject.GetComponent<SwitchToSoul>().SwitchToSoulAfterDeath();
        }
    }

    public void HurtBody(int damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
