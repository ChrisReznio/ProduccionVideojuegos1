using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToPlayer : MonoBehaviour
{
    PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject theController = GameObject.FindGameObjectWithTag("Player");
            theController.GetComponent<PlayerController>().isInputEnabled = true;
            theController.GetComponent<PlayerController>().canBeDamaged = true;

            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<CameraController>().followTarget = GameObject.Find("Player");

            GameObject soul = GameObject.FindGameObjectWithTag("Soul");
            soul.GetComponent<SoulController>().IsInputEnabled = false;

            soul.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
