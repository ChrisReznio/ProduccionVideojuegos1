﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    
    public float moveSpeed;
    private Animator anim;
    private bool bodyMoving;
    private Vector2 lastMove;
    private Rigidbody2D myRigidbody;
    public bool isInputEnabled = false;
    public bool canBeDamaged = false;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public GameObject throwableSpear;
    public float skillThrowSpearCooldown;
    public float throwSpearInterCooldown;
    public GameObject throwingPoint;

    public float dashSpeed;
    private bool dashing;
    public float dashRange;
    private float actualDashRange;
    public float skillDashCooldown;
    public float dashInternCooldown;

    private GameObject audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody= GetComponent<Rigidbody2D>();
        audioSource = GameObject.FindGameObjectWithTag("Source");

        throwSpearInterCooldown = 0;

        dashing = false;
        dashInternCooldown = 0;

        anim.SetFloat("LastMoveX", 0);
        anim.SetFloat("LastMoveY", -1);
        anim.SetBool("PlayerAttacking", false);
        anim.SetBool("ThrowingSpear", false);
        anim.SetBool("PlayerMoving", false);
        anim.SetBool("PlayerDashing", false);
    }

    void Update()
    {
        
        if (PauseMenu.isPaused)
        {
            myRigidbody.velocity = Vector2.zero;
            anim.speed = 0;
            return;
        }
        anim.speed = 1;
        if (anim.GetBool("Dying"))
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        bodyMoving = false;

        if(!dashing){
            myRigidbody.velocity = Vector2.zero;
        }

        if (isInputEnabled && !dashing)
        {
            bodyMoving =  true;

            if(!attacking)
            {
                if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    bodyMoving = false;
                }
                else
                {
                    myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                    anim.SetFloat("MoveX", lastMove.x);
                    anim.SetFloat("MoveY", lastMove.y);

                    anim.SetFloat("LastMoveX", lastMove.x);
                    anim.SetFloat("LastMoveY", lastMove.y);
                }
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    attackTimeCounter = attackTime;
                    attacking =  true;
                    myRigidbody.velocity = Vector2.zero;
                    audioSource.GetComponent<AudioController>().Swing();
                    anim.SetBool("PlayerAttacking", true);

                }else if(Input.GetKeyDown(KeyCode.X) && throwSpearInterCooldown <= 0){
                    anim.SetBool("ThrowingSpear", true);
                    audioSource.GetComponent<AudioController>().Throw();
                    throwSpearInterCooldown = skillThrowSpearCooldown;
                }
            }

            if (Input.GetKeyDown(KeyCode.C) && dashInternCooldown <= 0)
            {
                audioSource.GetComponent<AudioController>().Dash();
                actualDashRange = 0;
                Vector2 velocity = ((new Vector2(anim.GetFloat("LastMoveX"), anim.GetFloat("LastMoveY"))).normalized) * dashSpeed;
                myRigidbody.velocity = velocity;
                dashing = true;
                dashInternCooldown = skillDashCooldown;
                attacking = false;
                anim.SetBool("PlayerAttacking", false);
            }

            if (attackTimeCounter > 0){
                attackTimeCounter -= Time.deltaTime;
            }
        
            if(attackTimeCounter <= 0){
                attacking =  false;
                anim.SetBool("PlayerAttacking", false);
            }
       

        }

        if (throwSpearInterCooldown > 0)
        {
            throwSpearInterCooldown -= Time.deltaTime;
        }

        if (dashInternCooldown > 0){
            dashInternCooldown -= Time.deltaTime;
        }

        if(actualDashRange < dashRange && dashing){
                actualDashRange += dashSpeed * Time.deltaTime;
            }

        if(actualDashRange >= dashRange && dashing){
            dashing = false;
            myRigidbody.velocity = Vector2.zero;
        }

        anim.SetBool("PlayerMoving", bodyMoving);
        anim.SetBool("PlayerDashing", dashing);
    }


    public void ThrowSpear()
    {
        Vector2 velocity = new Vector2(anim.GetFloat("LastMoveX"), anim.GetFloat("LastMoveY"));
        Spear spear = Instantiate(throwableSpear, throwingPoint.transform.position, Quaternion.identity).GetComponent<Spear>();
        float zRotation = Mathf.Atan2(-anim.GetFloat("LastMoveX"), anim.GetFloat("LastMoveY")) * Mathf.Rad2Deg;
        spear.Setup(velocity, new Vector3(0, 0, zRotation));
    }

    public void FinishThrowSpear()
    {
        anim.SetBool("ThrowingSpear", false);
    }
}
