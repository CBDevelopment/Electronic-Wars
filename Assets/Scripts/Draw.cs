using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject theBoss;
    public GameObject theStylus;
    public Transform throwPos;
    public Animator anim;
    public Rigidbody2D myBody;
    public float behaviorTimer;
    public int currentHealth;
    public int maxHealth;
    public bool bossActive;
    public bool canTakeDamage;
    public SpriteRenderer SpriteRenderer;

    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;
    public Vector3 currentTarget;
    public bool canMove;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentTarget = endPoint.position;
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        behaviorTimer -= Time.deltaTime;

        if(behaviorTimer <= 0)
        {
            anim.SetBool("Attacking", true);

        }
        if(behaviorTimer <= -9)
        {
            anim.SetBool("Attacking", false);
        }
        if (behaviorTimer <= -10)
        {
            anim.SetBool("Ramming", true);
            canMove = true;
        }
        if(behaviorTimer <= -14)
        {
            anim.SetBool("Ramming", true);
            SpriteRenderer.flipX = true;

        }
        if(behaviorTimer <= -17)
        {
            canMove = false;
            anim.SetBool("Ramming", false);
            SpriteRenderer.flipX = false;
        }


        //Ram Movement
        if (canMove)
        {
            theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position, currentTarget, moveSpeed * Time.deltaTime);

            if (theBoss.transform.position == endPoint.transform.position)
            {
                currentTarget = startPoint.position;
                SpriteRenderer.flipX = true;

            }

            if (theBoss.transform.position == startPoint.transform.position)
            {
                currentTarget = endPoint.position;
            }
        }
    }

    void FixedUpdate()
    {


    }

        public void ThrowStylus()
    {
        //instantiate this instead.
        //theStylus.gameObject.SetActive(true);

        Instantiate(theStylus, throwPos.position, throwPos.rotation);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "AttackTrigger" && canTakeDamage)
        {
            currentHealth--;


            if (currentHealth <= 0)
            {
                theBoss.gameObject.SetActive(false);
                //Instantiate(deathSplosion, theBoss.transform.position, theBoss.transform.rotation);
                //tabPhaser.gameObject.SetActive(true);
                //healthBar.gameObject.SetActive(false);
                //bossMusic.gameObject.SetActive(false);
                //wallToRemove.gameObject.SetActive(false);
                //updateObject.gameObject.SetActive(true);
            }
        }
    }
}
