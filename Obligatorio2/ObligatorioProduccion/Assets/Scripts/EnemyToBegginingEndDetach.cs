using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToBegginingEndDetach : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.transform.SetParent(transform.parent.parent.parent);
        }
    }
}

