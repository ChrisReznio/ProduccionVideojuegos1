using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToPlayer : MonoBehaviour
{
    private GameObject soul;
    private GameObject player;
    private GameObject cam;
    private GameObject hitbox;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        soul = GameObject.FindGameObjectWithTag("Soul");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        hitbox = GameObject.FindGameObjectWithTag("SoulBox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !soul.GetComponent<SoulController>().canDealDamage)
        {
            player.GetComponent<PlayerController>().isInputEnabled = true;
            player.GetComponent<PlayerController>().canBeDamaged = true;

            cam.GetComponent<CameraController>().followTarget = GameObject.Find("Player");

            soul.GetComponent<SoulController>().IsInputEnabled = false;

            soul.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
