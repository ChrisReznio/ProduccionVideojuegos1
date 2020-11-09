using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaiaController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public bool IsInputEnabled = true;
    public bool canDealDamage = true;
    public Rigidbody2D rb;
    private GameObject body;
    private GameObject soul;

    public float distanceA;

    void Start()
    {
        rb.isKinematic = true;
        body = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");
        distanceA = 7;
    }
    void Update()
    {
        if (IsInputEnabled)
        {
            if (!animator.GetBool("Is_attacking"))
            { 
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

                /*if (!body.GetComponent<BodyController>().canBeDamaged || (soul.transform.position.x < body.transform.position.x + distance && soul.transform.position.x > body.transform.position.x - distance)
                && (soul.transform.position.y < body.transform.position.y + distance && soul.transform.position.y > body.transform.position.y - distance))
                {
                    transform.position = transform.position + movement * Time.deltaTime * moveSpeed;
                }
                else 
                {
                    transform.position = transform.position-(transform.position-body.transform.position)+movement * moveSpeed * Time.deltaTime;
                }*/
                transform.position = transform.position + movement * Time.deltaTime * moveSpeed;

                if (body.GetComponent<BodyController>().canBeDamaged)
                {
                    float radius = distanceA; //radius of *black circle*
                    Vector3 centerPosition = body.transform.localPosition; //center of *black circle*
                    float distance = Vector3.Distance(transform.position, centerPosition); //distance from ~green object~ to *black circle*

                    if (distance > radius) //If the distance is less than the radius, it is already within the circle.
                    {
                        Vector3 fromOriginToObject = transform.position - centerPosition; //~GreenPosition~ - *BlackCenter*
                        fromOriginToObject *= radius / distance; //Multiply by radius //Divide by Distance
                        transform.position = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
                animator.SetBool("Is_attacking", true);
        }
    }

    void StopAttack()
    {
        if (animator.GetBool("Is_attacking"))
            animator.SetBool("Is_attacking", false);
    }

    void CheckWithinRadius() 
    {
        
    }
}