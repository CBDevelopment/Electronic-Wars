using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController tvPlayer;
    public PlasmaPlayer plasmaPlayer;
    private PlayerGun playerGunScript;
    private PlayerRouter playerRouterScript;
    private Evolve evolveScript;
    private BatteryHealth batteryHealthScript;
    private Boss boss1;
    public GameObject deathBreak;
    private LevelEnd levelEndScript;
    private GunPickup gunPickupScript;
    private RouterPickup routerPickupScript;
    private StartCutScene startcut;
    private Upgrade upgradeScript;
    public GameObject vpnHUDImage;
    private NPCServer npcServerScript;

    //Global Things to save on the level.
    public int memCount;
    public Text memText;
    public int upgradeCount;
    public Text upgradeText;
    public int phaserBulletCount;
    public Text phaserBulletText;

    private bool respawning;

    public ResetOnRespawn[] objectsToReset;
    public int currentLives;
    public int startingLives;
    public Text livesText;
    public GameObject gameOverScreen;
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource gameoverMusicAddition;
    public bool tutorialMessageActive = false;
    public int FirstServerMissionCompleted = 0;


    // Use this for initialization
    void Start () {

        //currentLives = startingLives;

        vpnHUDImage.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();
        evolveScript = FindObjectOfType<Evolve>();
        batteryHealthScript = FindObjectOfType<BatteryHealth>();
        boss1 = FindObjectOfType<Boss>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();
        levelEndScript = FindObjectOfType<LevelEnd>();
        gunPickupScript = FindObjectOfType<GunPickup>();
        routerPickupScript = FindObjectOfType<RouterPickup>();
        startcut = FindObjectOfType<StartCutScene>();
        upgradeScript = FindObjectOfType<Upgrade>();
        npcServerScript = FindObjectOfType<NPCServer>();

        //***********************LOADING SAVE DATA********************************************
        if (PlayerPrefs.HasKey("HasDoneFirstServerMission"))
        {
            FirstServerMissionCompleted = PlayerPrefs.GetInt("HasDoneFirstServerMission");
        }

        if (PlayerPrefs.HasKey("ShieldChargeCount"))
        {
            playerRouterScript.shieldChargeCount = PlayerPrefs.GetInt("ShieldChargeCount");
        }
        playerRouterScript.shieldChargeText.text = playerRouterScript.shieldChargeCount.ToString();


        if (PlayerPrefs.HasKey("HasRouter"))
        {
            tvPlayer.hasRouter = PlayerPrefs.GetInt("HasRouter");
        }

        if (PlayerPrefs.HasKey("HasVPN"))
        {
            tvPlayer.hasVPN = PlayerPrefs.GetInt("HasVPN");
        }

        if (PlayerPrefs.HasKey("HasGun"))
        {
            tvPlayer.hasGun = PlayerPrefs.GetInt("HasGun");
        }

        //Checks for if you have phaser bullets. If there you do, it will load those back.
        //CODE GOES HERE
        //
        if (PlayerPrefs.HasKey("PhaserBulletCount"))
        {
            playerGunScript.phaserBulletCount = PlayerPrefs.GetInt("PhaserBulletCount");
        }

        playerGunScript.phaserBulletText.text = playerGunScript.phaserBulletCount.ToString();

        //Checks for if you have memory cards, and if there is value, load it back.
        if (PlayerPrefs.HasKey("MemCount"))
        {
            memCount = PlayerPrefs.GetInt("MemCount");
        }
        memText.text = memCount.ToString();

        //Checks for if you have upgrades, and if there is a value, load it back.
        if (PlayerPrefs.HasKey("UpgradeCount"))
        {
            upgradeCount = PlayerPrefs.GetInt("UpgradeCount");
        }
        upgradeText.text = upgradeCount.ToString();

        //Checks for if you have lives, and if there is value, load it back.
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }

        else
        {
            currentLives = startingLives;
        }

        //currentLives = startingLives;
        livesText.text = "x " + currentLives;
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
	}

    //// Update is called once per frame
    void Update()
    {
        //Update the text every frame.
        memText.text = memCount.ToString();
        livesText.text = "x" + currentLives.ToString();
        upgradeText.text = upgradeCount.ToString();

        if (tvPlayer.hasVPN == 1)
        {

            vpnHUDImage.SetActive(true);

        }

        if (tvPlayer.hasGun == 1)
        {

            gunPickupScript.slot1Image.gameObject.SetActive(true);

        }

        if (tvPlayer.hasRouter == 1)
        {

            routerPickupScript.slot2Image.gameObject.SetActive(true);

        }

        //Checks for if you have beaten the first level, and gotten a update already. If so, don't show the cutscene again.
        if(upgradeCount >= 1)
        {
            startcut.theCollider.enabled = false;
        }

        if (tutorialMessageActive)
        {
            tvPlayer.canMove = false;
            plasmaPlayer.canMove = false;
            Time.timeScale = 0;


            if (Input.GetButtonDown("Transform"))
            {
                if(boss1.upgradeMessageActive && !boss1.upgradeMessage2Active)
                {
                    boss1.UpgradeMessage.SetActive(false);
                    boss1.TutorialHolder.SetActive(false);
                    tutorialMessageActive = false;
                    Time.timeScale = 1;
                }

            }

        }

        if (!tutorialMessageActive)
        {
            tvPlayer.canMove = true;
            plasmaPlayer.canMove = true;
        }

    }


    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "x " + currentLives;

        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            tvPlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameoverMusicAddition.Play();
            gameOverMusic.Play();
        }

    }

    public void PlasmaRespawn()
    {
        currentLives -= 1;
        livesText.text = "x " + currentLives;

        if (currentLives > 0)
        {
            StartCoroutine("PlasmaRespawnCo");
        }
        else
        {
            plasmaPlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameoverMusicAddition.Play();
            gameOverMusic.Play();
        }

    }

    //If you're tv, this is the respawn coroutine when dying as TV.
    public IEnumerator RespawnCo()
    {
        tvPlayer.gameObject.SetActive(false);
        //tvPlayer.playerCollider.enabled = false;


        Instantiate(deathBreak, tvPlayer.transform.position, tvPlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        tvPlayer.transform.position = tvPlayer.respawnPosition;

        tvPlayer.gameObject.SetActive(true);
        //tvPlayer.playerCollider.enabled = true;


        //reset objects in game.
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }

        //sets health back to full on respawn
        tvPlayer.currentHealth = tvPlayer.maxHealth;
        tvPlayer.transform.position = tvPlayer.respawnPosition;
    }

    //Plasma's respawn. Dying as plasma form.
    public IEnumerator PlasmaRespawnCo()
    {
        plasmaPlayer.gameObject.SetActive(false);

        Instantiate(deathBreak, plasmaPlayer.transform.position, plasmaPlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        //evolveScript.Transform();

        plasmaPlayer.transform.position = tvPlayer.respawnPosition;

        //tvPlayer.gameObject.SetActive(true);

        //reset objects in game.
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }

    }


    public void AddMemory(int memToAdd)
    {
        memCount += memToAdd;
        memText.text = memCount.ToString();

    }

    public void AddPhaserBullets(int phaserBulletsToAdd)
    {
        playerGunScript.phaserBulletCount += phaserBulletsToAdd;
        phaserBulletText.text = playerGunScript.phaserBulletCount.ToString();
    }

    public void AddUpgrade(int upgradeToAdd)
    {
        upgradeCount += upgradeToAdd;
        upgradeText.text = upgradeCount.ToString();
    }

    public void AddLives(int livestoAdd)
    {
        currentLives += livestoAdd;
        livesText.text = "x " + currentLives;

    }

    public void AddHealth(int livestoAdd)
    {
        tvPlayer.currentHealth += batteryHealthScript.healthValue;
    }

}
