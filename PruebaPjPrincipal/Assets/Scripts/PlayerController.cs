using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private Rigidbody2D myRigidbody;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerMoving =  true;

        if(!attacking)
        {
             //Vector3 movement =  new Vector3(Input.GetAxisRaw("Horizontal") , 
            //                            Input.GetAxisRaw("Vertical") , 0f);
            //transform.position = transform.position + movement * Time.deltaTime * moveSpeed;

            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 
                                                Input.GetAxisRaw("Vertical") * moveSpeed);
            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
                playerMoving =  false;
            }else{
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }

            if(Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking =  true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("PlayerAttacking", true);
            }
        }

        if(attackTimeCounter > 0){
            attackTimeCounter -= Time.deltaTime;
        }
        
        if(attackTimeCounter <= 0){
            attacking =  false;
             anim.SetBool("PlayerAttacking", false);
        }
       
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
