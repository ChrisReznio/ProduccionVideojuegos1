using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{ 

    public void Respawn() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Body");
        player.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        player.GetComponent<BodyController>().canBeDamaged = false;
        player.GetComponent<BodyController>().isInputEnabled = false;
        GameObject soul = GameObject.FindGameObjectWithTag("Soul");
        soul.GetComponent<SoulController>().canDealDamage = false;

        BodyHealthManager bhm = player.GetComponent<BodyHealthManager>();
        bhm.currentHealth = bhm.maxHealth;

        BodyDetachController bdc = player.GetComponent<BodyDetachController>();
        bdc.ResetAll();
    }
}
