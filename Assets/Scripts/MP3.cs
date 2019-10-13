using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP3 : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D myBody;
    public float moveSpeed;
    private float minX, maxX;
    public float distance;
    public int direction;
    private Transform playerPos;
    public bool patrol, detect;
    public Animator anim;

    [Header("Attack")]
    public GameObject attackTrigger;
    public AudioSource attackFX;
    //public Transform attackPos;
    //public float attackRange;
    //public LayerMask playerLayer;
    //public int damage;

    public void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    public void Start()
    {
        maxX = transform.position.x + (distance / 2);
        minX = maxX - distance;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Vector3.Distance(transform.position, playerPos.position) <= 10f)
        {
            patrol = false;
        }
        else
        {
            patrol = true;
        }
        
    }

    public void FixedUpdate()
    {
        if (myBody.velocity.x > 0)
        {
            transform.localScale = new Vector2(-.8f, transform.localScale.y);
            anim.SetBool("Attacking", false);
        }
        else if (myBody.velocity.x < 0)
        {
            transform.localScale = new Vector2(.8f, transform.localScale.y);
        }

        if (patrol)
        {
            switch (direction)
            {
                case -1:
                    if (transform.position.x > minX)
                        myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
                    else
                        direction = 1;
                    break;
                case 1:
                    if (transform.position.x < maxX)
                        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
                    else
                        direction = -1;
                    break;
            }
        }
        else
        {
            if (Vector2.Distance(playerPos.position, transform.position) >= 7f)
            {
                if (!detect)
                {
                    detect = true;
                    anim.SetTrigger("Detect");
                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Detect")) return;

                Vector3 playerDir = (playerPos.position - transform.position).normalized;

                if (playerDir.x > 0)
                    myBody.velocity = new Vector2(moveSpeed + 0.4f, myBody.velocity.y);
                else
                    myBody.velocity = new Vector2(-moveSpeed + 0.4f, myBody.velocity.y);
            }
            else if (Vector2.Distance(playerPos.position, transform.position) <= 6f)
            {
                myBody.velocity = new Vector2(0, myBody.velocity.y);
                anim.SetBool("Attacking", true);
            }
        }

    }

    public void Attack()
    {
        //myBody.velocity = new Vector2(0, myBody.velocity.y);
        //Collider2D attackPlayer = Physics2D.OverlapCircle(attackPos.position, attackRange, playerLayer);

        //if(attackPlayer != null)
        //{
        //   if(attackPlayer.tag == "Player")
        //    {
        //        //damage player
        //    }
        //}

        attackTrigger.gameObject.SetActive(true);
        attackFX.Play();
        StartCoroutine(AttackReset());
    }

    public IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(.1f);
        attackTrigger.gameObject.SetActive(false);
    }
}
