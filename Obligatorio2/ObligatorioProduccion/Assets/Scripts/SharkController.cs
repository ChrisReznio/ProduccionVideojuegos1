using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    public float visionRange;

    private float timeBetweenMoveCounter;
    private Rigidbody2D myRigidBody;
    private GameObject body;
    private Transform target;
    private bool inContactWithBody;
    private Animator animator;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        timeBetweenMoveCounter = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
                    animator.SetFloat("MoveX", direction.x);
                    animator.SetFloat("MoveY", direction.y);
                    myRigidBody.MovePosition(myRigidBody.position + moveSpeed * direction * Time.fixedDeltaTime);
                }
                else
                {
                    timeBetweenMoveCounter -= Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Body")
        {
            timeBetweenMoveCounter = timeBetweenMove;
        }
    }

    private bool BodyInSight()
    {
        return (Vector3.Distance(transform.position, target.position) < visionRange);
    }

    private Vector2 GetDirection()
    {

        return (target.position - transform.position).normalized;
    }
}
