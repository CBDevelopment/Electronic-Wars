using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Network1Boss : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 50;
    public GameObject bullet;

    public float timeBetweenShots;
    public float startTimeBetweenShots;

    public float timeBetweenShots2;
    public float startTimeBetweenShots2;

    public Transform shotPointTop;
    public Transform shotPointBottom;
    public Transform shotPointMiddle;

    public AudioSource DamageFX;

    public Animator anim;

    //Movement
    public GameObject objectToMove;

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    private Vector3 currentTarget;

    public Slider healthBar;

    public bool bossActive;

    public GameObject deathSplosion;

    public bool bossDied = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentTarget = endPoint.position;
        healthBar.gameObject.SetActive(false);
        objectToMove.gameObject.SetActive(false);

    }

    // Update is called once per frame
    public void Update()
    {
        healthBar.value = currentHealth;

        if (bossActive)
        {
            healthBar.gameObject.SetActive(true);
            objectToMove.gameObject.SetActive(true);


            if (timeBetweenShots <= 0)
            {
                Instantiate(bullet, shotPointTop.transform.position, shotPointTop.transform.rotation);
                Instantiate(bullet, shotPointBottom.transform.position, shotPointBottom.transform.rotation);

                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
            //-----------------------------------------------------------
            if (timeBetweenShots2 <= 0)
            {
                Instantiate(bullet, shotPointMiddle.transform.position, shotPointMiddle.transform.rotation);

                timeBetweenShots2 = startTimeBetweenShots2;
            }
            else
            {
                timeBetweenShots2 -= Time.deltaTime;
            }

        }

        if(currentHealth <= 0)
        {
            //objectToMove.SetActive(false);
            bossActive = false;
            healthBar.gameObject.SetActive(false);
            objectToMove.GetComponent<SpriteRenderer>().enabled = false;
            bossDied = true;
            objectToMove.gameObject.SetActive(false);
        }

    }

    //momvement
    void FixedUpdate()
    {
        if (bossActive)
        {


            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

            if (objectToMove.transform.position == endPoint.position)
            {
                currentTarget = startPoint.position;
            }

            if (objectToMove.transform.position == startPoint.position)
            {
                currentTarget = endPoint.position;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AttackTrigger")
        {
            currentHealth -= 1;
            DamageFX.Play();
            StartCoroutine(ResetAnimation());

            if(currentHealth == 1)
            {
                Instantiate(deathSplosion, objectToMove.transform.position, objectToMove.transform.rotation);
            }
            //DestroyProjectile();
        }
    }

    public IEnumerator ResetAnimation()
    {
        anim.SetBool("Damaged", true);
        yield return new WaitForSeconds(.1f);
        anim.SetBool("Damaged", false);
    }
}