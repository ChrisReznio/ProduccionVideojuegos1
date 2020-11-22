using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActivateRotator : MonoBehaviour
{
    private Collider2D rotator;
    private GameObject body;
    private float waitCounter;
    private float waitTime;
    private bool waiting;
    private float offsetY;
    //private bool rotating;
    // Start is called before the first frame update
    void Start()
    {
        offsetY = 0.76f;
        body = GameObject.FindGameObjectWithTag("Body");
        waitTime = 30;
        waitCounter = 0;
        waiting = false;
        //rotating = false;
        //rotatedDegrees = 0;
        //rotatingFloor
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitCounter==0 && Input.GetKey(KeyCode.Z) && rotator != null && RotatorIsInRange(rotator))
        {
            Vector3 position = rotator.transform.parent.gameObject.transform.position;
            Vector3 bodyPosition = body.transform.position;

            if ((bodyPosition.x > position.x + 2.40 || bodyPosition.x <= position.x - 2.40)
                || (bodyPosition.y > position.y + 2.40 + offsetY || bodyPosition.y <= position.y - 2.40 + offsetY))
            {
                foreach (Transform child in rotator.transform.parent.gameObject.transform)
                {
                    if (child.tag == "BodyBox" || child.tag == "SoulBox")
                    {
                        Vector3 childPosition = child.transform.position;
                        if (childPosition.x > position.x + 1.6f)
                        {
                            child.position = new Vector3(position.x + 1.6f, child.position.y, 0);
                        }
                        else if (childPosition.x < position.x - 1.6f)
                        {
                            child.position = new Vector3(position.x - 1.6f, child.position.y, 0);
                        }

                        if (childPosition.y > position.y + 1.6f)
                        {
                            child.position = new Vector3(child.position.x, position.y + 1.6f, 0);
                        }
                        else if (childPosition.y < position.y - 1.6f)
                        {
                            child.position = new Vector3(child.position.x, position.y - 1.6f, 0);
                        }
                    }
                }
                rotator.GetComponent<Animator>().SetBool("Pressed", true);
                rotator.transform.parent.gameObject.transform.Rotate(new Vector3(0, 0, 90));
                rotator.transform.Rotate(new Vector3(0, 0, -90));
                foreach (Transform child in rotator.transform.parent.gameObject.transform)
                {
                    if(child.tag == "Enemy" || child.tag ==  "BodyBox" || child.tag == "SoulBox")
                    {
                        child.Rotate(0, 0, -90);
                    }
                }
            }

            waiting = true;
        }

        if (waiting)
        {
            waitCounter++;
            if (waitCounter == waitTime)
            {
                if(rotator != null)
                {
                    rotator.GetComponent<Animator>().SetBool("Pressed", false);
                }
                waiting = false;
                waitCounter = 0;
            }
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Activable" && body.GetComponent<BodyController>().canBeDamaged)
        {
            rotator = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Activable" && body.GetComponent<BodyController>().canBeDamaged)
        {
            rotator.GetComponent<Animator>().SetBool("Pressed", false);
            rotator = null;
        }
    }

    private bool RotatorIsInRange(Collider2D rotator)
    {
        return this.transform.position.x < rotator.transform.position.x + 1 &&
            this.transform.position.x > rotator.transform.position.x - 1 &&
            this.transform.position.y < rotator.transform.position.y + 1 &&
            this.transform.position.y > rotator.transform.position.y - 1;
    }
}
