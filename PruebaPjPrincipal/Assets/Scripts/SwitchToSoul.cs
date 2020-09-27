using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToSoul : MonoBehaviour
{
    private GameObject soul;
    private GameObject player;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       soul   = GameObject.FindGameObjectWithTag("Soul");
       cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {

            if (player.GetComponent<PlayerController>().isInputEnabled)
            {
                SwitchSoulOnCommand();
            }
            else 
            {
                SwitchSoulOnCommand();
                soul.transform.position = player.transform.position + new Vector3(0, 0, 0);
            }
            
        }
    }

    public void SwitchSoulPeriodic()
    {
        SwitchSoulOnCommand();
        soul.GetComponent<SoulController>().canDealDamage = true;
    }

    public void SwitchSoulOnCommand() 
    {
        player.GetComponent<PlayerController>().isInputEnabled = false;

        soul.transform.localScale = new Vector3(1, 1, 0);
        soul.GetComponent<SoulController>().IsInputEnabled = true;
        soul.GetComponent<SoulController>().canDealDamage = false;
        
        soul.transform.position = player.transform.position+new Vector3(2,2,0);

        cam.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");

    }

    
    public void SwitchToSoulAfterDeath() 
    {
        player.GetComponent<PlayerController>().isInputEnabled = false;
        player.GetComponent<PlayerController>().canBeDamaged = false;

        soul.transform.localScale = new Vector3(1, 1, 0);
        soul.GetComponent<SoulController>().IsInputEnabled = true;
        soul.GetComponent<SoulController>().canDealDamage = false;

        soul.transform.position = player.transform.position + new Vector3(2, 2, 0);

        cam.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");

        RespawnPlayer();
    }

    void RespawnPlayer() {
        player.GetComponent<RespawnController>().Respawn();
    }
}
