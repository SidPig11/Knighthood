using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour {

    private bool attack = false;
    private Animator anim;

    public Collider2D Attack;

    private void Awake()
    {
        anim.gameObject.GetComponent<Animator>();
        Attack.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            attack = true;
            Attack.enabled = true;
        }

        anim.SetTrigger("Attack");
    }
}
