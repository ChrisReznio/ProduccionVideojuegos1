using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToSoul : MonoBehaviour
{
    private GameObject soul;
    private GameObject body;
    private GameObject cam;

    void Start()
    {
       body = GameObject.FindGameObjectWithTag("Body");
       soul   = GameObject.FindGameObjectWithTag("Soul");
       cam = GameObject.FindGameObjectWithTag("MainCamera");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)&&body.GetComponent<BodyController>().canBeDamaged && !PauseMenu.isPaused) 
        {

            if (body.GetComponent<BodyController>().isInputEnabled)
            {
                SwitchSoulOnCommand();
            }
            else
            {
                SwitchSoulOnCommand();
                soul.transform.position = body.transform.position + new Vector3(0, 0, 0);
            }

        }
    }

    //public void SwitchSoulPeriodic()
    //{
    //    SwitchSoulOnCommand();
    //    soul.GetComponent<SoulController>().canDealDamage = true;
    //}

    public void SwitchSoulOnCommand() 
    {
        soul.transform.GetChild(0).GetComponent<ActivateRotator>().enabled = true;
        body.GetComponent<BodyController>().isInputEnabled = false;
        soul.transform.localScale = new Vector3(1, 1, 0);
        soul.GetComponent<SoulController>().IsInputEnabled = true;
        soul.GetComponent<SoulController>().canDealDamage = true;
        soul.transform.position = body.transform.position + new Vector3(0, 1, 0);
        cam.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");

    }


    public void SwitchToSoulAfterDeath() 
    {
        body.GetComponent<BodyController>().isInputEnabled = false;
        body.GetComponent<BodyController>().canBeDamaged = false;

        soul.transform.localScale = new Vector3(1, 1, 0);
        soul.GetComponent<SoulController>().IsInputEnabled = true;
        soul.GetComponent<SoulController>().canDealDamage = false;

        soul.transform.position = body.transform.position + new Vector3(0, 0, 0);

        cam.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");

        RespawnBody();
    }

    void RespawnBody() {
        body.GetComponent<RespawnController>().Respawn();
    }
}
