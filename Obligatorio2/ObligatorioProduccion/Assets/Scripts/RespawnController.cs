using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{ 

    public void Respawn() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Body");
        player.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;

        BodyHealthManager bhm = player.GetComponent<BodyHealthManager>();
        bhm.Start();
    }
}
