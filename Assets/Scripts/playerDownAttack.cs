using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDownAttack : MonoBehaviour
{

    private bool downattacking = false;

    public float attackTimer = 3;
    public float attackCD = .38f;

    public Collider2D downAttackTrigger;

    private Animator anim;


    private void Start()
    {

    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        downAttackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("DownAttack") && !downattacking)
        {
            downattacking = true;
            attackTimer = attackCD;
            downAttackTrigger.enabled = true;
        }
        

        if (downattacking)
        {

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                downattacking = false;
                downAttackTrigger.enabled = false;
            }

            anim.SetBool("DownAttacking", downattacking);

        }
    }


}
