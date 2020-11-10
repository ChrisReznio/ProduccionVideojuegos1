using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBoxInteractionController : MonoBehaviour
{

    private GameObject body;
    public Rigidbody2D myRigidbody2d;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
    }
    
    void Update()
    {
        bool isBody = body.GetComponent<BodyController>().isInputEnabled;
        if (!isBody)
        {
            myRigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            myRigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
