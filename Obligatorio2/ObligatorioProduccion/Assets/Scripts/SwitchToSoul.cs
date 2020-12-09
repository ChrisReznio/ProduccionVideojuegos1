using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToSoul : MonoBehaviour
{
    private GameObject soul;
    private GameObject body;
    private GameObject cam;

    private GameObject audioSource;

    void Start()
    {
       body = GameObject.FindGameObjectWithTag("Body");
       soul   = GameObject.FindGameObjectWithTag("Soul");
       cam = GameObject.FindGameObjectWithTag("MainCamera");
       audioSource = GameObject.FindGameObjectWithTag("Source");

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
        audioSource.GetComponent<AudioController>().Separate();
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

       
        cam.GetComponent<CameraController>().followTarget = GameObject.Find("Soul");

        RespawnBody();

        soul.transform.position = body.transform.position + new Vector3(0, 0, 0);
    }

    void RespawnBody() {
        body.GetComponent<RespawnController>().Respawn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
