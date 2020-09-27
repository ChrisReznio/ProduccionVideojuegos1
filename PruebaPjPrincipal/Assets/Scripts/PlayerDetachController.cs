using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetachController : MonoBehaviour
{
    public float currentCounter;
    public float detachThreshold;
    public float detachedRunCounter;
    public float detachedReturnThreshold;

    private GameObject player;
    private GameObject soul;
    // Start is called before the first frame update
    void Start()
    {
        currentCounter = 0;
        detachThreshold = 1800;
        detachedRunCounter = 0;
        detachedReturnThreshold = 600;

        player = GameObject.FindGameObjectWithTag("Player");
        soul = GameObject.FindGameObjectWithTag("Soul");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<PlayerController>().isInputEnabled) 
        {
            currentCounter++;
        }
        if (currentCounter == detachThreshold)
        {
            currentCounter = 0;
            player.GetComponent<SwitchToSoul>().SwitchSoulPeriodic();
        }
        if (player.GetComponent<PlayerController>().canBeDamaged) 
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
