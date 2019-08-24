using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;
    public string leveltoUnlock;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private PlayerGun playerGunScript;
    private PlayerRouter playerRouterScript;
    private LevelManager theLevelManagerScript;
    public AudioSource levelExitMusic;
    public GameObject levelCompleteImage;
    private Boss bossScript;

    // Use this for initialization
    void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        theLevelManagerScript = FindObjectOfType<LevelManager>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();
        bossScript = FindObjectOfType<Boss>();
        levelCompleteImage.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine("LevelEndCo");
            tvPlayer.canMove = false;
        }
    }

    public IEnumerator LevelEndCo()
    {

        theLevelManagerScript.levelMusic.Stop();
        

        levelExitMusic.Play();
        levelCompleteImage.SetActive(true);
        bossScript.bossMusic.Stop();


        //****************************SAVING***************************************

        //Saves stuff at the end of the level.
        PlayerPrefs.SetInt("MemCount", theLevelManagerScript.memCount);
        PlayerPrefs.SetInt("UpgradeCount", theLevelManagerScript.upgradeCount);
        PlayerPrefs.SetInt("PlayerLives", theLevelManagerScript.currentLives);
        PlayerPrefs.SetInt("PhaserBulletCount", playerGunScript.phaserBulletCount);
        PlayerPrefs.SetInt("ShieldChargeCount", playerRouterScript.shieldChargeCount);
        PlayerPrefs.SetInt("HasGun", tvPlayer.hasGun);
        PlayerPrefs.SetInt("HasVPN", tvPlayer.hasVPN);
        PlayerPrefs.SetInt("HasRouter", tvPlayer.hasRouter);
        PlayerPrefs.SetInt(leveltoUnlock, 1);
        
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(levelToLoad);
    }
}
