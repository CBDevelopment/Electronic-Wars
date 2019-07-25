using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;
    public string leveltoUnlock;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private PlayerGun playerGunScript;
    private LevelManager theLevelManagerScript;

	// Use this for initialization
	void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        theLevelManagerScript = FindObjectOfType<LevelManager>();
        playerGunScript = FindObjectOfType<PlayerGun>();
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
            plasmaPlayer.canMove = false;
        }
    }

    public IEnumerator LevelEndCo()
    {

        theLevelManagerScript.levelMusic.Stop();

//****************************SAVING***************************************

        //Saves stuff at the end of the level.
        PlayerPrefs.SetInt("MemCount", theLevelManagerScript.memCount);
        PlayerPrefs.SetInt("UpgradeCount", theLevelManagerScript.upgradeCount);
        PlayerPrefs.SetInt("PlayerLives", theLevelManagerScript.currentLives);
        PlayerPrefs.SetInt("PhaserBulletCount", playerGunScript.phaserBulletCount);
        // *** Saves that you got the gun. ****
        PlayerPrefs.SetInt("HasGun", tvPlayer.hasGun);
        PlayerPrefs.SetInt("HasRouter", tvPlayer.hasRouter);
        PlayerPrefs.SetInt(leveltoUnlock, 1);

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(levelToLoad);
    }
}
