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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeBetweenMoveCounter = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
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
                Debug.Log("si");
                if (TouchingPlayer())
                {
                    ResetMovement();
                }
                else
                {
                    if (timeBetweenMoveCounter <= 0f)
                    {
                        Vector3 direction = (target.position - transform.position).normalized;
                        myRigidBody.velocity = moveSpeed * direction;
                    }
                    else
                    {
                        timeBetweenMoveCounter -= Time.deltaTime;
                    }
                }
            }
        }
    }

    bool PlayerInSight()
    {
        return (Vector3.Distance(transform.position, target.position) < visionRange);
    }

    bool TouchingPlayer()
    {
        return (Vector3.Distance(transform.position, target.position) < 0.8);
    }

    void ResetMovement()
    {
        timeBetweenMoveCounter = timeBetweenMove;
        myRigidBody.velocity = Vector3.zero;
    }
}
