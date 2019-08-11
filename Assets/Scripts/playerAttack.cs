using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public bool attacking = false;

    public float attackTimer = 5;
    public float attackCD = .38f;

    public Collider2D attackTrigger;

    public Animator anim;

    public bool animationPlaying = false;

    public void Start()
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
            anim.SetTrigger("Attacking");
            animationPlaying = true;

        }

        if (attacking)
        {

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 1)
                {

                    if (animationPlaying)
                    {
                        attackTrigger.enabled = true;

                    }

                }
            }
            
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
                anim.ResetTrigger("Attacking");
            }
        }

            
    }


}
