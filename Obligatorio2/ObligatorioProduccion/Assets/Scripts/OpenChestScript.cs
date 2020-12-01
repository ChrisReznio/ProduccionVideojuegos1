using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestScript : MonoBehaviour
{

    private Animator anim;
    public GameObject heart;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    
    void Update() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            if (!anim.GetBool("IsOpened"))
            {
                anim.SetBool("IsOpened", true);
                Vector3 position = gameObject.transform.parent.transform.position;
                position.y = position.y - 0.4f;
                Instantiate(heart, position, Quaternion.identity);
            }
        }
    }
}
