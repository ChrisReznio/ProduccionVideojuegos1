using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearSkillUI : MonoBehaviour
{
    public Image imageCooldown;
    private bool isInCooldown = false;
    private float cooldown = 0;

    void Update()
    {
        cooldown = GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().skillThrowSpearCooldown;
        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().isInputEnabled && GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().throwSpearInterCooldown > 0)
        {
            if(isInCooldown == false)
            {
                imageCooldown.fillAmount = 0;
                isInCooldown = true;
            }
        }
        if (isInCooldown)
        {
            if (!PauseMenu.isPaused)
            {
                imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
                if (imageCooldown.fillAmount >= 1)
                {
                    isInCooldown = false;
                }
            }
        }
    }
}
