using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToFloorAtachment : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.transform.SetParent(null);
            collider.transform.SetParent(transform.parent.parent.parent.parent);
        }
        if (collider.gameObject.tag == "BoxRotatorCollider")
        {
            collider.transform.parent.SetParent(null);
            collider.transform.parent.SetParent(transform.parent.parent.parent.parent);
        }
    }
}
