using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public BodyHealthManager bodyHealth;

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
        }
        else 
        {
            DisableWidgets();
        }
    }

    private void EnableWidgets() 
    {
        healthBar.gameObject.SetActive(true);

       

        HPText.gameObject.SetActive(true);
       
    }

    private void DisableWidgets() 
    {
        healthBar.gameObject.SetActive(false);
       

        HPText.gameObject.SetActive(false);
       
    }
}
