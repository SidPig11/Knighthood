using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public Collider2D Attack;


    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool attack = false;
    private float attacktimer = 0;
    private float attackCd = 0.3f;

    void Awake()
    {
        Attack.enabled = false;  
    }


    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Attack"))
        {
            attack = true;
            animator.SetTrigger("Attack");
            attacktimer = attackCd;
            Attack.enabled = true;
        }
        if (attack)
        {
            if (attacktimer > 0)
            {
                attacktimer -= Time.deltaTime;
            }
            else
            {
                attack = false;
                Attack.enabled = false;
            }
        }
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}