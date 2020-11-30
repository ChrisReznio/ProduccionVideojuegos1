using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Animator anim;
    private GameObject audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("Source");
    }

    public void HurtBody(int damage)
    {
        currentHealth -= damage;
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
}
