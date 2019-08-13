using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public bool attacking = false;
    public float attackTimer = .2f;
    public float attackCD = .2f;
    public float timeBetweenAttack = .19f;
    public bool canAttack;

    public Collider2D attackTrigger;

    public Animator anim;
    private PlayerController tvPlayer;

    public bool animationPlaying = false;

    public void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetButtonDown("Attack") && !attacking)
            {
                attacking = true;
                attackTimer = attackCD;
                anim.SetTrigger("Attacking");
                tvPlayer.meleeSound.Play();
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
                    animationPlaying = false;
                    timeBetweenAttack = .19f;

                }
            }
        }

        timeBetweenAttack -= Time.deltaTime;

    }


}
