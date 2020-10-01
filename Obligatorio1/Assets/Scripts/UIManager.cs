using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public BodyHealthManager bodyHealth;

    public Slider detachTimer;
    public Text detachText;

    public Slider reattachTimer;
    public Text reattachText;

    public BodyDetachController bdc;

    void Start()
    {
        bdc = GameObject.FindGameObjectWithTag("Body").GetComponent<BodyDetachController>();
    }


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().canBeDamaged)
        {
            EnableWidgets();

            healthBar.maxValue = bodyHealth.maxHealth;
            healthBar.value = bodyHealth.currentHealth;
            HPText.text = "HP: " + bodyHealth.currentHealth + "/" + bodyHealth.maxHealth;

            detachTimer.maxValue = bdc.detachThreshold / 60;
            detachTimer.value = bdc.currentCounter / 60;
            detachText.text = "Time to dettach left " + (int)((bdc.detachThreshold - bdc.currentCounter) / 60);

            reattachTimer.maxValue = bdc.detachedReturnThreshold / 60;
            reattachTimer.value = bdc.detachedRunCounter / 60;
            reattachText.text = "Time to reattach left " + (int)((bdc.detachedReturnThreshold - bdc.detachedRunCounter) / 60);
        }
        else 
        {
            DisableWidgets();
        }
    }

    private void EnableWidgets() 
    {
        healthBar.gameObject.SetActive(true);
        detachTimer.gameObject.SetActive(true);
        reattachTimer.gameObject.SetActive(true);

        HPText.gameObject.SetActive(true);
        detachText.gameObject.SetActive(true);
        reattachText.gameObject.SetActive(true);
    }

    private void DisableWidgets() 
    {
        healthBar.gameObject.SetActive(false);
        detachTimer.gameObject.SetActive(false);
        reattachTimer.gameObject.SetActive(false);

        HPText.gameObject.SetActive(false);
        detachText.gameObject.SetActive(false);
        reattachText.gameObject.SetActive(false);
    }
}
