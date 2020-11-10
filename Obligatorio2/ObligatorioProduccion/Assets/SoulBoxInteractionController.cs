using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBoxInteractionController : MonoBehaviour
{

    private GameObject soul;
    public Rigidbody2D myRigidbody2d;

    void Start()
    {
        soul = GameObject.FindGameObjectWithTag("Soul");
    }
    
    void Update()
    {
        bool isSoul = soul.GetComponent<SoulController>().IsInputEnabled;
        if (!isSoul)
        {
            myRigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            myRigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
