using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBody : MonoBehaviour
{
    public int damage;

    void Start(){}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Body")
        {
            GameObject theController = GameObject.FindGameObjectWithTag("Body");
            if (theController.GetComponent<BodyController>().canBeDamaged)
            {
                other.gameObject.GetComponent<BodyHealthManager>().HurtBody(damage);
            }
        }
    }
}
