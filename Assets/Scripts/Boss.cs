using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public bool bossActive;

    public float timeBetweenDrops;

    private float dropCount;
    public float waitForOpening;
    private float openingCount;

    public GameObject lighting;
    public GameObject lightingSplosion;

    public Transform leftPoint;
    public Transform rightPoint;
    public Transform lightingSpawn;

    public GameObject theBoss;
    public GameObject lightningWallRight;
    public GameObject lightningWallLeft;

    public bool bossRight;
    public bool bossLeft;

    public bool takeDamage;
    public int startingHealth;
    public int currentHealth;


    public AudioSource bossMusic;
    public AudioSource levelMusic;


    public bool isTriggered;
    public bool bossFlipped;

    public SpriteRenderer theSpriteRenderer;
    private FlipOnX flipScript;
    private PlayerController tvPlayer;
    public Animator anim;

    //public int numberOfBoss1Kills;
    private LevelManager theLevelManager;
    public GameObject theUpgradeObject;

    public Slider healthBar;

    public GameObject TutorialHolder;
    public GameObject UpgradeMessage;
    public GameObject UpgradeMessage2;
    public GameObject memoryCardRewards;

    // Use this for initialization
    void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
        flipScript = FindObjectOfType<FlipOnX>();
        theLevelManager = FindObjectOfType<LevelManager>();
        TutorialHolder.SetActive(false);
        bossActive = false;

        theUpgradeObject.SetActive(false);
        lightningWallLeft.SetActive(false);
        lightningWallRight.SetActive(false);
        dropCount = timeBetweenDrops;
        openingCount = waitForOpening;
        currentHealth = startingHealth;

        theBoss.transform.position = rightPoint.position;
        bossRight = true;

        flipScript = FindObjectOfType<FlipOnX>();

        currentHealth = startingHealth;

        anim.SetBool("Attacking", false);
        anim.SetBool("Teleporting", false);
        anim.SetFloat("Speed", 0f);

    }

    // Update is called once per frame
    void Update () {

        healthBar.value = currentHealth;


        if (bossActive)
        {
            healthBar.gameObject.SetActive(true);
            this.anim.SetBool("Attacking", true);

            if (tvPlayer.currentHealth <= 0)
            {
                
                
                flipScript.theSpriteRenderer.flipX = false;
                theBoss.transform.position = rightPoint.position;
            }
            
            theBoss.SetActive(true);
            lightningWallLeft.SetActive(true);
            lightningWallRight.SetActive(true);

            if (dropCount > 0)
            {
                dropCount -= Time.deltaTime;
            }

            else
            {
                lightingSpawn.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), lightingSpawn.position.y, lightingSpawn.position.z);
                Instantiate(lighting, lightingSpawn.position, lightingSpawn.rotation);
                Instantiate(lightingSplosion, lightingSpawn.position, lightingSpawn.rotation);
                dropCount = timeBetweenDrops;
            }

            //if (bossRight)
            //{
            //    //if (openingCount > 0)
            //    //{
            //    //    openingCount -= Time.deltaTime;
            //    //}
            //    //else
            //    //{
            //    //    shield.SetActive(true);
            //    //}
            //}

            if (takeDamage)
            {

                currentHealth -= 1;

                if (bossRight)
                {
                    anim.Play("PluggyTeleport");

                    flipScript.theSpriteRenderer.flipX = true;
                    theBoss.transform.position = leftPoint.position;
                    
                }
                else
                {
                    anim.Play("PluggyTeleport");
                    theBoss.transform.position = rightPoint.position;
                    flipScript.theSpriteRenderer.flipX = false;
                }
                bossRight = !bossRight;
                takeDamage = false;
            }

            if(currentHealth <= 0)
            {
                theBoss.SetActive(false);
                bossActive = false;
                lightningWallLeft.SetActive(false);
                lightningWallRight.SetActive(false);
                healthBar.gameObject.SetActive(false);
                //Spawn 50 Mb when destroying the boss.
                Instantiate(memoryCardRewards, theBoss.gameObject.gameObject.transform.position, theBoss.gameObject.gameObject.transform.rotation);
                Instantiate(memoryCardRewards, theBoss.gameObject.gameObject.transform.position, theBoss.gameObject.gameObject.transform.rotation);
                Instantiate(memoryCardRewards, theBoss.gameObject.gameObject.transform.position, theBoss.gameObject.gameObject.transform.rotation);
                Instantiate(memoryCardRewards, theBoss.gameObject.gameObject.transform.position, theBoss.gameObject.gameObject.transform.rotation);
                Instantiate(memoryCardRewards, theBoss.gameObject.gameObject.transform.position, theBoss.gameObject.gameObject.transform.rotation);

            }

            if (currentHealth <=0 && theLevelManager.upgradeCount < 1)
            {
                theUpgradeObject.SetActive(true);
            }

        }

        if (Input.GetButtonDown("Transform"))
        {
            TutorialHolder.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered == false)
        {
            if (other.tag == "Player")
            {

                bossActive = true;
                levelMusic.Stop();
                bossMusic.Play();
            }
        }      
}

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = true; 
    }

    public void Next()
    {
        UpgradeMessage.SetActive(false);
        UpgradeMessage2.SetActive(true);

    }

    public void Close()
    {
        //This is turned on by the UpgradeScript.
        //TutorialHolder.SetActive(false);
    }
}