using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDetachController : MonoBehaviour
{

    private GameObject player;
    private GameObject soul;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");
    }
    
    void FixedUpdate()
    {
  
    }


}
