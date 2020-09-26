using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToSoul : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            SwitchSoul();
        }
    }

    void SwitchSoul() 
    {
        GameObject theController = GameObject.FindGameObjectWithTag("Player");
        theController.GetComponent<PlayerController>().isInputEnabled = false;

        GameObject soul = GameObject.FindGameObjectWithTag("Soul");

        soul.transform.localScale = new Vector3(1, 1, 0);
        soul.GetComponent<SoulController>().IsInputEnabled = true;
        

        soul.transform.position = theController.transform.position+new Vector3(2,2,0);

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");
    }

    public void SwitchToSoulAfterDeath() 
    {
        GameObject theController = GameObject.FindGameObjectWithTag("Player");
        theController.GetComponent<PlayerController>().isInputEnabled = false;
        theController.GetComponent<PlayerController>().canBeDamaged = false;

        GameObject soul = GameObject.FindGameObjectWithTag("Soul");
        soul.transform.localScale = new Vector3(1, 1, 0);
        soul.GetComponent<SoulController>().IsInputEnabled = true;

        soul.transform.position = theController.transform.position + new Vector3(2, 2, 0);

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");

        RespawnPlayer();
    }

    void RespawnPlayer() {
        GameObject theController = GameObject.FindGameObjectWithTag("Player");
        theController.GetComponent<RespawnController>().Respawn();
    }
}
