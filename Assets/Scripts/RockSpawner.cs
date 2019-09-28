using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockSpawner : MonoBehaviour
{
    public float timeBetweenDrops;

    private float dropCount;
    private float openingCount;

    public GameObject rock;
    //public GameObject lightingSplosion;

    public Transform upPoint;
    public Transform bottomPoint;
    //public Transform rightUpPoint;
    //public Transform leftUpPoint;
    public Transform rockSpawn;

    //public int numberOfBoss1Kills;
    private LevelManagerNetwork levelManagerNetworkScript;

    //public GameObject damageSplosion;
    //public GameObject destroySplosion;


    // Use this for initialization
    void Start()
    {

        //tvPlayer = FindObjectOfType<PlayerController>();
        //flipScript = FindObjectOfType<FlipOnX>();
        //theLevelManager = FindObjectOfType<LevelManager>();
        //pauseScript = FindObjectOfType<PauseMenu>();
        //TutorialHolder.SetActive(false);
        //bossActive = false;
        //levelEndBlocker.enabled = false;
        //theColliderBox.enabled = true;
        //rb2d = theBoss.GetComponent<Rigidbody2D>();
        //plasmaPlayer = FindObjectOfType<PlasmaPlayer>();

        //theUpgradeObject.SetActive(false);
        //lightningWallLeft.SetActive(false);
        //lightningWallRight.SetActive(false);
        //dropCount = timeBetweenDrops;
        //openingCount = waitForOpening;
        //currentHealth = startingHealth;

        //theBoss.transform.position = rightPoint.position;
        //bossRight = true;

        //flipScript = FindObjectOfType<FlipOnX>();

        //currentHealth = startingHealth;

        //anim.SetBool("Attacking", false);
        //anim.SetBool("Teleporting", false);
        //anim.SetFloat("Speed", 0f);

    }

    // Update is called once per frame
    void Update()
    {    
            if (dropCount > 0)
            {
                dropCount -= Time.deltaTime;
            }

            else
            {
                rockSpawn.position = new Vector3(Random.Range(upPoint.position.x, bottomPoint.position.x), rockSpawn.position.y, rockSpawn.position.z);
                Instantiate(rock, rockSpawn.position, rockSpawn.rotation);
                //Instantiate(lightingSplosion, lightingSpawn.position, lightingSpawn.rotation);
                dropCount = timeBetweenDrops;
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {



    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }

    public void Next()
    {
    }

    public void Close()
    {
    }
}