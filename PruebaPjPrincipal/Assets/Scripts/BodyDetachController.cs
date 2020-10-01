using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDetachController : MonoBehaviour
{
    public float currentCounter;
    public float detachThreshold;
    public float detachedRunCounter;
    public float detachedReturnThreshold;

    private GameObject player;
    private GameObject soul;


    void Start()
    {
        currentCounter = 0;
        detachThreshold = 1800;
        detachedRunCounter = 0;
        detachedReturnThreshold = 600;

        player = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");
    }
    
    void FixedUpdate()
    {
        if (player.GetComponent<BodyController>().isInputEnabled) 
        {
            currentCounter++;
        }
        if (currentCounter == detachThreshold)
        {
            currentCounter = 0;
            player.GetComponent<SwitchToSoul>().SwitchSoulPeriodic();
        }
        if (player.GetComponent<BodyController>().canBeDamaged) 
        {
            if (soul.GetComponent<SoulController>().canDealDamage)
            {
                detachedRunCounter++;
            }
            if (detachedRunCounter == detachedReturnThreshold)
            {
                player.GetComponent<SwitchToSoul>().SwitchSoulOnCommand();
                soul.transform.position = player.transform.position + new Vector3(0, 0, 0);
                detachedRunCounter = 0;
            }
        }
    }

    public void ResetAll()
    {
        currentCounter = 0;
        detachedRunCounter = 0;
    }
}
