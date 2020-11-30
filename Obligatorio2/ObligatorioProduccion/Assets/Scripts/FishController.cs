using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    public float visionRange;
    public float attackRange;

    private float timeBetweenMoveCounter;
    private Rigidbody2D myRigidBody;
    private GameObject body;
    private Transform target;
    private Animator animator;
    private GameObject audioSource;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        timeBetweenMoveCounter = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("CanIddle", true);
        audioSource = GameObject.FindGameObjectWithTag("Source");
    }


    void Update()
    {
        myRigidBody.velocity = Vector2.zero;
        if (body.GetComponent<BodyController>().canBeDamaged)
        {
            target = body.GetComponent<Transform>();
            if (BodyInSight())
            {
                if (timeBetweenMoveCounter <= 0f && !BodyInAttackRange())
                {
                    Vector2 direction = GetDirection();
                    myRigidBody.MovePosition(myRigidBody.position + moveSpeed * direction * Time.fixedDeltaTime);
                    animator.SetBool("IsMoving", true);
                }
                else if(timeBetweenMoveCounter <= 0f && BodyInAttackRange())
                {
                    Vector2 distance = target.position - transform.position;
                    Vector2 normalized = distance.normalized;
                    if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
                    {
                        animator.SetFloat("MovementX", distance.x / Mathf.Abs(distance.x));
                        animator.SetFloat("MovementY", 0);
                    }
                    else
                    {
                        animator.SetFloat("MovementX", 0);
                        animator.SetFloat("MovementY", distance.y / Mathf.Abs(distance.y));
                    }
                    animator.SetBool("IsMoving", false);
                    animator.SetBool("CanIddle", false);
                    animator.SetBool("IsAttacking", true);
                    
                    timeBetweenMoveCounter = timeBetweenMove;
                }
                else
                {
                    timeBetweenMoveCounter -= Time.deltaTime;
                    animator.SetBool("IsMoving", false);
                }
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }

    public void DisableAttack()
    {
        animator.SetBool("CanIddle", true);
        animator.SetBool("IsAttacking", false);
    }

    public void KillFish()
    {
        Destroy(gameObject);
    }

    public void Electrocute()
    {
        float positionX = target.position.x;
        float positionY = target.position.y;
        foreach (Transform child in transform)
        {
            if (child.tag == "Spark")
            {
                child.position = new Vector2(positionX, positionY);
                
                child.transform.gameObject.SetActive(true);
            }
        }
        audioSource.GetComponent<AudioController>().Fish();
    }

    private bool BodyInSight()
    {
        return (Vector3.Distance(transform.position, target.position) < visionRange);
    }

    private bool BodyInAttackRange()
    {
        return (Vector3.Distance(transform.position, target.position) < attackRange);
    }

    private Vector2 GetDirection()
    {
        Vector2 distance = target.position - transform.position;
        Vector2 normalized = distance.normalized;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            animator.SetFloat("MovementX", distance.x / Mathf.Abs(distance.x));
            animator.SetFloat("MovementY", 0);
        }
        else
        {
            animator.SetFloat("MovementX", 0);
            animator.SetFloat("MovementY", distance.y / Mathf.Abs(distance.y));
        }
        return normalized;
    }
}
