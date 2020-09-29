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
    public bool isInputEnabled = false;
    public bool canBeDamaged = false;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public GameObject throwableSpear;

    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = Vector2.zero;
        playerMoving = false;

        if (isInputEnabled)
        {
            playerMoving =  true;

            if(!attacking)
            {
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

                }else if(Input.GetKeyDown(KeyCode.K)){
                    Vector2 velocity = new Vector2(anim.GetFloat("LastMoveX"), anim.GetFloat("LastMoveY"));
                    Spear spear = Instantiate(throwableSpear, transform.position, Quaternion.identity).GetComponent<Spear>();
                    float zRotation = Mathf.Atan2(-anim.GetFloat("LastMoveX"), anim.GetFloat("LastMoveY")) * Mathf.Rad2Deg;
                    spear.Setup(velocity, new Vector3(0,0, zRotation + 225));
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
            
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }

        anim.SetBool("PlayerMoving", playerMoving);
    }
}
