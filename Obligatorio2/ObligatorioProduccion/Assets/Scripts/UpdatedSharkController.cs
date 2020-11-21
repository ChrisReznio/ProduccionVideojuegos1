using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedSharkController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    public float visionRange;

    private float timeBetweenMoveCounter;
    private Rigidbody2D myRigidBody;
    private GameObject body;
    private Transform target;
    private Animator animator;


    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        timeBetweenMoveCounter = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("CanIddle", true);
    }


    void Update()
    {
        myRigidBody.velocity = Vector2.zero;
        if (body.GetComponent<BodyController>().canBeDamaged)
        {
            target = body.GetComponent<Transform>();
            if (BodyInSight())
            {
                if (timeBetweenMoveCounter <= 0f)
                {
                    Vector2 direction = GetDirection();
                    myRigidBody.MovePosition(myRigidBody.position + moveSpeed * direction * Time.fixedDeltaTime);
                    animator.SetBool("IsMoving", true);
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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("CanIddle", false);
            animator.SetTrigger("IsAttacking");
            timeBetweenMoveCounter = timeBetweenMove;
        }
    }

    public void EnableIddle()
    {
        animator.SetBool("CanIddle", true);
    }

    public void KillShark()
    {
        Destroy(gameObject);
    }

    private bool BodyInSight()
    {
        return (Vector3.Distance(transform.position, target.position) < visionRange);
    }

    private Vector2 GetDirection()
    {
        Vector2 distance = target.position - transform.position;
        Vector2 normalized = distance.normalized;
        if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            animator.SetFloat("MovementX", distance.x/Mathf.Abs(distance.x));
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

