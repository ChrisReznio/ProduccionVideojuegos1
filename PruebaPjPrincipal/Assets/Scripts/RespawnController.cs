using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;

        PlayerHealthManager pc = player.GetComponent<PlayerHealthManager>();
        pc.currentHealth = pc.maxHealth;
    }
}
