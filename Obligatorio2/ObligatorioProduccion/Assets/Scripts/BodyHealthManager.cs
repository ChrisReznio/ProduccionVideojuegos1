using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Animator anim;
    private GameObject audioSource;

    public void Start()
    {
        currentHealth = StaticValues.ActualLife;
        if (StaticValues.ActualLife <= 0) {
            currentHealth = maxHealth;
        }
        anim = GetComponent<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("Source");
        PlayerPrefs.SetInt("maxHealth", maxHealth);
    }

    public void HurtBody(int damage)
    {
        currentHealth -= damage;
        StaticValues.ActualLife = currentHealth;
        if (currentHealth <= 0)
        {
            audioSource.GetComponent<AudioController>().Die();
            anim.SetBool("Dying", true);
        }
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void DeleteBody()
    {
        gameObject.GetComponent<SwitchToSoul>().SwitchToSoulAfterDeath();
        anim.SetBool("Dying", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Heart")
        {
            currentHealth += 10;
            StaticValues.ActualLife = currentHealth;
            collision.gameObject.active = false;
        }
    }
}
