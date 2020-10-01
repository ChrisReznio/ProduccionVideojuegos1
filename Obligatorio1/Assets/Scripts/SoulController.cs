using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public bool IsInputEnabled = true;
    public bool canDealDamage = true;

    void Update()
    {
        if (IsInputEnabled)
        {
            if (!animator.GetBool("Is_attacking"))
            { 
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
                transform.position = transform.position + movement * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKeyDown(KeyCode.Space))
                animator.SetBool("Is_attacking", true);
        }
    }

    void StopAttack()
    {
        if (animator.GetBool("Is_attacking"))
            animator.SetBool("Is_attacking", false);
    }
}