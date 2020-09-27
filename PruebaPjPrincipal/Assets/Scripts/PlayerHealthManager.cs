using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            if (!gameObject.GetComponent<PlayerController>().isInputEnabled)
                gameObject.GetComponent<RespawnController>().Respawn();
            else
                gameObject.GetComponent<SwitchToSoul>().SwitchToSoulAfterDeath();
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
