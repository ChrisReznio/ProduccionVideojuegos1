using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToBody : MonoBehaviour
{
    private GameObject soul;
    private GameObject body;
    private GameObject cam;
    public GameObject hitbox;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Body")
        {
            hitbox.GetComponent<ActivateRotator>().enabled = false;
            body.GetComponent<BodyController>().isInputEnabled = true;
            body.GetComponent<BodyController>().canBeDamaged = true;

            cam.GetComponent<CameraController>().followTarget = body;

            soul.GetComponent<SoulController>().IsInputEnabled = false;

            soul.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
