using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    public float visionRange;

    private float timeBetweenMoveCounter;
    private Rigidbody2D myRigidBody;
    private GameObject body;
    private Transform target;
    private bool inContactWithPlayer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Player");
        timeBetweenMoveCounter = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = Vector2.zero;
        if (body.GetComponent<PlayerController>().canBeDamaged)
        {
            target = body.GetComponent<Transform>();
            if (PlayerInSight())
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
        if (collision.gameObject.name == "Player")
        {
            timeBetweenMoveCounter = timeBetweenMove;
        }
    }

    private bool PlayerInSight()
    {
        return (Vector3.Distance(transform.position, target.position) < visionRange);
    }

    private Vector2 GetDirection()
    {

        Vector2 direction;
        if (Mathf.Abs(target.position.x - transform.position.x) >= Mathf.Abs(target.position.y - transform.position.y))
        {
            direction = new Vector2(target.position.x - transform.position.x, 0).normalized;
        }
        else
        {
            direction = new Vector2(0, target.position.y - transform.position.y).normalized;
        }
        return direction;
    }
}
