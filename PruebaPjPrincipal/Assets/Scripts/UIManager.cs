using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    public Slider detachTimer;
    public Text detachText;

    public Slider reattachTimer;
    public Text reattachText;

    public PlayerDetachController pdc;
    // Start is called before the first frame update
    void Start()
    {
        pdc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDetachController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;
        HPText.text = "HP: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
    }

    void FixedUpdate()
    {
        detachTimer.maxValue = pdc.detachThreshold/60;
        detachTimer.value = pdc.currentCounter/60;
        detachText.text = "Time to dettach left " + (int)((pdc.detachThreshold - pdc.currentCounter) / 60);

        reattachTimer.maxValue = pdc.detachedReturnThreshold / 60; 
        reattachTimer.value = pdc.detachedRunCounter / 60; 
        reattachText.text = "Time to reattach left " + (int)((pdc.detachedReturnThreshold - pdc.detachedRunCounter) / 60);
    }
}
