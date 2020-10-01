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
    private GameObject player;
    private Transform target;
    private bool inContactWithPlayer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeBetweenMoveCounter = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        inContactWithPlayer = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<PlayerController>().canBeDamaged)
        {
            myRigidBody.velocity = Vector3.zero;
        }
        else
        {
            target = player.GetComponent<Transform>();
            if (PlayerInSight())
            {
                if (inContactWithPlayer)
                {
                    ResetMovement();
                    inContactWithPlayer = false;
                }
                else
                {
                    if (timeBetweenMoveCounter <= 0f)
                    {
                        Vector3 direction = (target.position - transform.position).normalized;
                        animator.SetFloat("MoveX", direction.x);
                        animator.SetFloat("MoveY", direction.y);
                        myRigidBody.velocity = moveSpeed * direction;
                    }
                    else
                    {
                        timeBetweenMoveCounter -= Time.deltaTime;
                    }
                }
            }
            else
            {
                ResetMovement();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inContactWithPlayer = true;
        }
    }

    bool PlayerInSight()
    {
        return (Vector3.Distance(transform.position, target.position) < visionRange);
    }

    bool TouchingPlayer()
    {
        return (Vector3.Distance(transform.position, target.position) < 1);
    }

    void ResetMovement()
    {
        timeBetweenMoveCounter = timeBetweenMove;
        myRigidBody.velocity = Vector3.zero;
    }
}
