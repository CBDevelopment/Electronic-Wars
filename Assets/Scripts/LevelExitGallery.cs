using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelExitGallery : MonoBehaviour
{
    public string levelToLoad;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private PlayerGun playerGunScript;
    private PlayerRouter playerRouterScript;
    private LevelManager theLevelManagerScript;
    public AudioSource levelMusic;
    private NPCServer npcServerScript;
    private Boss bossScript;

    // Start is called before the first frame update
    public void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        theLevelManagerScript = FindObjectOfType<LevelManager>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();
        npcServerScript = FindObjectOfType<NPCServer>();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine("SceneExit");
            tvPlayer.canMove = false;
            plasmaPlayer.canMove = false;

        }
    }

    public IEnumerator SceneExit()
    {

        theLevelManagerScript.levelMusic.Stop();


        levelMusic.Stop();

        //****************************SAVING***************************************

        //Saves stuff at the end of the level.
        //PlayerPrefs.SetInt("MemCount", theLevelManagerScript.memCount);
        PlayerPrefs.SetInt("UpgradeCount", theLevelManagerScript.upgradeCount);
        PlayerPrefs.SetInt("PlayerLives", theLevelManagerScript.currentLives);
        PlayerPrefs.SetInt("PhaserBulletCount", playerGunScript.phaserBulletCount);
        PlayerPrefs.SetInt("ShieldChargeCount", playerRouterScript.shieldChargeCount);
        PlayerPrefs.SetInt("HasGun", tvPlayer.hasGun);
        PlayerPrefs.SetInt("HasVPN", tvPlayer.hasVPN);
        PlayerPrefs.SetInt("HasRouter", tvPlayer.hasRouter);
        //PlayerPrefs.SetInt("HasTalkedToServer", npcServerScript.hasTalkedOnce);


        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelToLoad);
    }
}
