using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MadTab : MonoBehaviour
{
    public GameObject theBoss;
    public bool bossActive = false;
    public float behaviorTimer;
    public Animator anim;
    public Transform rightPointUp;
    public Transform rightPointDown;
    public Transform leftPointUp;
    public Transform leftPointDown;
    public Transform midPoint;
    public SpriteRenderer SpriteRenderer;
    public GameObject bulletRight;//the projectile he shoots that travel to right
    public GameObject bulletLeft; //the projectile he shoots that travel to left.
    public bool canShootLeft;
    public bool canShootRight;
    public Transform shotPointLeft;
    public Transform shotPointRight;
    public GameObject shieldObject;//the shield around him until he reloads.
    public int maxHealth;
    public int currentHealth;
    public bool canTakeDamage;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public BoxCollider2D damageTriggerBox;
    private CameraFollow theCameraFollowScript;
    private PlayerController tvPlayer;
    public GameObject ActivateTriggerBox;
    public GameObject deathSplosion;
    public GameObject tabPhaser;
    private BossDialog bossDialogScript;
    public Slider healthBar;
    public GameObject enemySpawn2;
    public Transform eSpawnPos2;
    public GameObject enemySpawn3;
    public Transform eSpawnPos3;
    public float SpawnerTimer;
    public GameObject bossMusic;
    private LevelManager levelManagerScript;
    public GameObject wallToRemove;
    public GameObject gunTrigger;

    //public GameObject henchMen;//summon little plugs on the bottom of the platform when he shoots from up top.

    // Start is called before the first frame update
    void Start()
    {
        theCameraFollowScript = FindObjectOfType<CameraFollow>();
        currentHealth = maxHealth;
        damageTriggerBox.enabled = false;
        tvPlayer = FindObjectOfType<PlayerController>();
        bossDialogScript = FindObjectOfType<BossDialog>();
        levelManagerScript = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;

        if (bossActive)
        {
            behaviorTimer -= Time.deltaTime;
            SpawnerTimer -= Time.deltaTime;
            healthBar.gameObject.SetActive(true);
            bossMusic.gameObject.SetActive(true);

            if (behaviorTimer > 0)
            {
                shieldObject.gameObject.SetActive(true);

                anim.SetBool("Attacking", false);
                anim.SetBool("Teleporting", false);
                anim.SetBool("Reloading", false);
            }

            if (behaviorTimer <= 0)
            {
                canShootLeft = true;
                anim.SetBool("Attacking", true);

            }

            if (behaviorTimer <= -5)
            {
                canShootLeft = false;
                anim.SetBool("Attacking", false);
            }

            if (behaviorTimer <= -6)
            {
                anim.SetBool("Teleporting", true);
                theBoss.transform.position = leftPointUp.position;
                SpriteRenderer.flipX = true;
                shieldObject.gameObject.SetActive(false);
            }

            if (behaviorTimer <= -7)
            {
                anim.SetBool("Teleporting", false);
                shieldObject.gameObject.SetActive(true);

            }

            if (behaviorTimer <= -8)
            {//instantiate  bullets here.
                anim.SetBool("Attacking", true);
                canShootRight = true;
            }

            if (behaviorTimer <= -13)
            {
                anim.SetBool("Attacking", false);
                canShootRight = false;
            }

            if (behaviorTimer <= -13.5)
            {
                anim.SetBool("Teleporting", true);
                theBoss.transform.position = midPoint.position;
                shieldObject.gameObject.SetActive(false);

                //SpriteRenderer.flipX = true;
            }

            if (behaviorTimer <= -16.5)
            {//reloading. Time to attack him here.
                anim.SetBool("Reloading", true);
                canTakeDamage = true;
                damageTriggerBox.enabled = true;

            }

            if (behaviorTimer <= -20)
            {
                canTakeDamage = false;
                anim.SetBool("Reloading", false);
                anim.SetBool("Teleporting", true);
                theBoss.transform.position = leftPointDown.position;
                damageTriggerBox.enabled = false;

            }

            if (behaviorTimer <= -21)
            {
                anim.SetBool("Teleporting", false);
                shieldObject.gameObject.SetActive(true);

            }

            if (behaviorTimer <= -22)
            {
                anim.SetBool("Attacking", true);
                canShootRight = true;

            }

            if (behaviorTimer <= -26)
            {
                anim.SetBool("Attacking", false);
                canShootRight = false;
            }

            if (behaviorTimer <= -27)
            {
                anim.SetBool("Attacking", false);
                anim.SetBool("Teleporting", true);
                theBoss.transform.position = rightPointUp.position;
                SpriteRenderer.flipX = false;
                shieldObject.gameObject.SetActive(false);

            }

            if (behaviorTimer <= -28)
            {
                anim.SetBool("Teleporting", false);
                shieldObject.gameObject.SetActive(true);

            }

            if (behaviorTimer <= -29)
            {
                anim.SetBool("Attacking", true);
                canShootLeft = true;
            }

            if (behaviorTimer <= -34)
            {
                canShootLeft = false;
                anim.SetBool("Attacking", false);
                anim.SetBool("Teleporting", true);
                shieldObject.gameObject.SetActive(false);
                theBoss.transform.position = midPoint.position;
            }

            if (behaviorTimer <= -35)
            {
                //anim.SetBool("Reloading", true);
                shieldObject.gameObject.SetActive(false);
                //canTakeDamage = true;
                //damageTriggerBox.enabled = true;

                //SpriteRenderer.flipX = true;
            }

            if(behaviorTimer <= -36)
            {
                anim.SetBool("Reloading", true);
                shieldObject.gameObject.SetActive(false);
                canTakeDamage = true;
                damageTriggerBox.enabled = true;
                SpriteRenderer.flipX = false;
            }

            if (behaviorTimer <= -40)
            {
                canTakeDamage = false;
                anim.SetBool("Reloading", false);
                anim.SetBool("Teleporting", true);
                theBoss.transform.position = rightPointDown.position;
                damageTriggerBox.enabled = false;

                //SpriteRenderer.flipX = true;
            }

            if (behaviorTimer <= -41)
            {
                behaviorTimer = 1;//change this as needed later.
            }

            if(SpawnerTimer <= 0)
            {
                Instantiate(enemySpawn3, eSpawnPos3.position, eSpawnPos3.rotation);
                SpawnerTimer = 8.5f;
            }

            /////////////////////////Reset the boss on death.
            if (tvPlayer.currentHealth <= 0)
            {
                bossActive = false;
                theBoss.transform.position = rightPointDown.position;
                SpriteRenderer.flipX = false;
                damageTriggerBox.enabled = false;
                behaviorTimer = 1.5f;
                anim.SetBool("Attacking", false);
                anim.SetBool("Teleporting", false);
                anim.SetBool("Reloading", false);
                canShootLeft = false;
                canShootRight = false;
                healthBar.gameObject.SetActive(false);
                gunTrigger.gameObject.SetActive(true);
            }
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

        if (canShootRight)
        {
            //Instantiate some bullets here.
            if (timeBetweenShots <= 0)
            {
                Instantiate(bulletRight, shotPointRight.position, transform.rotation);

                timeBetweenShots = startTimeBetweenShots;

            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }

        if (canShootLeft)
        {
            //Instantiate some bullets here.
            if (timeBetweenShots <= 0)
            {
                Instantiate(bulletLeft, shotPointLeft.position, transform.rotation);

                timeBetweenShots = startTimeBetweenShots;

            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "AttackTrigger" && canTakeDamage)
        {
                currentHealth--;


            if (currentHealth <= 0)
            {
                theBoss.gameObject.SetActive(false);
                Instantiate(deathSplosion, theBoss.transform.position, theBoss.transform.rotation);
                tabPhaser.gameObject.SetActive(true);
                healthBar.gameObject.SetActive(false);
                bossMusic.gameObject.SetActive(false);
                wallToRemove.gameObject.SetActive(false);
            }
        }
    }
}
