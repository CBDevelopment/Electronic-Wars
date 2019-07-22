using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public bool attacking = false;

    public float attackTimer = 3;
    public float attackCD = .38f;

    public Collider2D attackTrigger;

    public Animator anim;


    private void Start()
    {

    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Attack") && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }

            anim.SetBool("Attacking", attacking);


        }
    }


}
