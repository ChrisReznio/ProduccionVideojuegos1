using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSkillUI : MonoBehaviour
{
    public Image imageCooldown;
    private bool isInCooldown = false;
    private float cooldown = 0;

    void Update()
    {
        cooldown = GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().skillDashCooldown;
        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().isInputEnabled && GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().dashInternCooldown > 0)
        {
            if (isInCooldown == false)
            {
                imageCooldown.fillAmount = 0;
                isInCooldown = true;
            }
        }
        if (isInCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
            if (imageCooldown.fillAmount >= 1)
            {
                isInCooldown = false;
            }
        }
    }
}