using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBody : MonoBehaviour
{
    public int damage;
    private float cooldownLeft;
    public float maxCooldown;

    void Start()
    {
        cooldownLeft = 0;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Body"){
            GameObject theController = GameObject.FindGameObjectWithTag("Body");
            if (theController.GetComponent<BodyController>().canBeDamaged && cooldownLeft <= 0)
            { 
                other.gameObject.GetComponent<BodyHealthManager>()
                                .HurtBody(damage);
                cooldownLeft = maxCooldown;
            }
        }
        cooldownLeft -= Time.deltaTime;
    }
}
