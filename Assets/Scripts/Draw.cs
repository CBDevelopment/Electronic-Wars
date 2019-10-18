using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Draw : MonoBehaviour
{
    public GameObject theBoss;
    public GameObject theStylus;
    public Transform target;
    public Transform throwPos;
    public Animator anim;
    public Rigidbody2D myBody;
    public float behaviorTimer;
    public int currentHealth;
    public int maxHealth;
    public bool bossActive;
    public bool canTakeDamage;
    public SpriteRenderer SpriteRenderer;
    public bool canStylusAttack;
    public float rotationSpeed;

    Quaternion rotateToTarget;
    Vector3 dir;
    public Slider healthBar;
    //public AudioSource bossMusic;

    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;
    public float secondaryMoveSpeed;
    public Vector3 currentTarget;
    public bool canMove;
    //public Collider2D ramCollider;
    public Collider2D myBodyCollider;
    //public Collider2D stylusFormCollider;
    public Collider2D myBodyTrigger;

    public float SpawnerTimer;
    public GameObject enemySpawn;
    public Transform eSpawnPos;
    public Transform eSpawnPos2;
    public Transform eSpawnPos3;
    public AudioSource ramSoundFX;
    public GameObject destroySplosion;

    public GameObject wallToRemove;
    public GameObject updateObject;
    private CameraFollow theCameraFollowScript;
    public GameObject ActivateTriggerBox;



    // Start is called before the first frame update
    void Start()
    {
        theCameraFollowScript = FindObjectOfType<CameraFollow>();

        currentHealth = maxHealth;
        currentTarget = endPoint.position;
        canMove = false;
        bossActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;

        if (bossActive)
        {
            healthBar.gameObject.SetActive(true);
            behaviorTimer -= Time.deltaTime;
            SpawnerTimer -= Time.deltaTime;
            canTakeDamage = true;

            //SpawnerTimer -= Time.deltaTime;
            //healthBar.gameObject.SetActive(true);
            //bossMusic.gameObject.SetActive(true);

            if (behaviorTimer <= 0)
            {
                anim.SetBool("Attacking", true);
            }

            if (behaviorTimer <= -9)
            {
                anim.SetBool("Attacking", false);
            }
            if (behaviorTimer <= -10)
            {
                anim.SetBool("Ramming", true);
                canMove = true;
                //stylusFormCollider.enabled = true;
            }
            if (behaviorTimer <= -14)
            {
                //rotate and go back
                SpriteRenderer.flipX = true;
            }
            if (behaviorTimer <= -17f)
            {
                //put the boss in the original position, 
                //stop him from charging across and 
                //turn him around back to idle.
                theBoss.transform.position = startPoint.position;
                canMove = false;
                anim.SetBool("Ramming", false);
                SpriteRenderer.flipX = false;
                //ramCollider.enabled = false;
            }

            if (behaviorTimer <= -19)
            {
                //Transform into the EnlargedStylus
                anim.SetBool("Transforming", true);
                canTakeDamage = false;
                myBodyCollider.enabled = false;
                myBodyTrigger.enabled = false;
                //stylusFormCollider.enabled = true;
            }

            if (behaviorTimer <= -28)
            {//reset boss
                anim.SetBool("Reverting", true);

                //anim.SetBool("Transforming", false);
                //canStylusAttack = true;
            }

            if (behaviorTimer <= -30)
            {//reset boss
                anim.SetBool("Transforming", false);
                anim.SetBool("Reverting", false);
                behaviorTimer = 4;
                myBodyCollider.enabled = true;
                myBodyTrigger.enabled = true;
            }
            if (SpawnerTimer <= -19 && behaviorTimer <= -20.9)
            {
                DestroyEnemySpawns();
            }

            if (SpawnerTimer <= -19 && behaviorTimer <= -21)
            {

                Instantiate(enemySpawn, eSpawnPos2.position, eSpawnPos2.rotation);
                //Instantiate(enemySpawn, eSpawnPos3.position, eSpawnPos3.rotation);
                SpawnerTimer = 4f;
            }

            if (bossActive)
            {
                ActivateTriggerBox.gameObject.SetActive(false);
                theCameraFollowScript.GetComponent<Camera>().orthographicSize = 17;
            }
            else
            {
                ActivateTriggerBox.gameObject.SetActive(true);
                theCameraFollowScript.GetComponent<Camera>().orthographicSize = 14;

            }

            //if(behaviorTimer <= -28)
            //{
            //    canStylusAttack = false;
            //    
            //}

            //Stylus Mode
            //if (canStylusAttack)
            //{
            //    //dir = (target.transform.position - transform.position).normalized;
            //    //float angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            //    //rotateToTarget = Quaternion.AngleAxis(angle, Vector3.forward);
            //    //transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);
            //    //myBody.velocity = new Vector2(dir.x * 2, dir.y * 2);
            //}

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


    }

    void FixedUpdate()
    {


    }

    public void ThrowStylus()
    {
        Instantiate(theStylus, throwPos.position, throwPos.rotation);
    }

    public void PlayRamSound()
    {
        ramSoundFX.Play();

    }

    public void DestroyEnemySpawns()
    {
        //Instantiate(destroySplosion, eSpawnPos2.position, eSpawnPos2.rotation);
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "AttackTrigger" && canTakeDamage)
        {
            currentHealth--;


            if (currentHealth <= 0)
            {
                theBoss.gameObject.SetActive(false);
                Instantiate(destroySplosion, theBoss.transform.position, theBoss.transform.rotation);
                //tabPhaser.gameObject.SetActive(true);
                healthBar.gameObject.SetActive(false);
                //bossMusic.gameObject.SetActive(false);
                wallToRemove.gameObject.SetActive(false);
                updateObject.gameObject.SetActive(true);
            }
        }
    }
}
