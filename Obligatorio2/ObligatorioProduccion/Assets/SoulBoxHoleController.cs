using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBoxHoleController : MonoBehaviour
{
    void Start() { }

    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SoulBox")
        {
            transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
