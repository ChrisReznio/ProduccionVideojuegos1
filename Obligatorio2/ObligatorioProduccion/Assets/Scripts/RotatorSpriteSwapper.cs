using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSpriteSwapper : MonoBehaviour
{
    public GameObject body;
    public Animator animator;
    private float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        offsetY = 0.76f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsBodyInRange())
        {
            DeactivateRotator();
        }
        else
        {
            ActivateRotator();
        }
    }

    void ActivateRotator()
    {
        animator.SetBool("Active", true);
    }

    void DeactivateRotator()
    {
        animator.SetBool("Active", false);
    }
    private bool IsBodyInRange()
    {
        Vector3 bodyPosition = body.transform.position;
        if ((bodyPosition.x > this.transform.position.x + 2.40 || bodyPosition.x <= this.transform.position.x - 2.40)
                || (bodyPosition.y > this.transform.position.y + 2.40 + offsetY || bodyPosition.y <= this.transform.position.y - 2.40 + offsetY))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
