using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;

    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;

    private Vector3 moveDirection;
    private Rigidbody2D myRigidBody;
    private bool moving;

    public float waitToReload;
    private bool reloading;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter =  Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;
            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter =  Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed,
                                            Random.Range(-1f, 1f) * moveSpeed,
                                            0f);
            }
        }

        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                player.SetActive(true);
            }
        }
    }

    
}
