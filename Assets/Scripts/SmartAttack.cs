using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartAttack : MonoBehaviour
{
    public Animator anim;

    public bool attacking=false;
    public bool animationPlaying;

    public float attackTimer = .2f;
    public float attackCD = .2f;
    public float timeBetweenAttack;

    public Collider2D smartAttackTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown("Attack") && attackAmount ==1)
        //{
        //    anim.SetBool("Attacking1",true);
        //}


        if (timeBetweenAttack <= 0)
        {
            if (Input.GetButtonDown("Attack"))
            {
                attacking = true;
                attackTimer = attackCD;
                anim.SetTrigger("Attacking3");
                //tvPlayer.meleeSound.Play();
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
                            smartAttackTrigger.enabled = true;

                        }
                    }
                }
                else
                {
                    attacking = false;
                    smartAttackTrigger.enabled = false;
                    anim.ResetTrigger("Attacking3");
                    animationPlaying = false;
                    timeBetweenAttack = .20f;

                }
            }
            
        }
        timeBetweenAttack -= Time.deltaTime;


    }

}
