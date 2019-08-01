using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneSimple : MonoBehaviour
{
    private LevelManager levelManagerScript;
    private PlayerController tvPlayer;
    private PlayerGun playerGunScript;
    private PlayerRouter playerRouterScript;
    private PlasmaPlayer plasmaPlayer;

    public string levelToLoad;

    void OnStart ()
    {
        levelManagerScript = FindObjectOfType<LevelManager>();
        tvPlayer = FindObjectOfType<PlayerController>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("LoadSceneCo");
            tvPlayer.canMove = false;
            plasmaPlayer.canMove = false;

        }

    }

    public IEnumerator LoadSceneCo()
    {

        levelManagerScript.levelMusic.Stop();


        //****************************SAVING***************************************

        //Saves stuff at the end of the level.
        PlayerPrefs.SetInt("MemCount", levelManagerScript.memCount);
        PlayerPrefs.SetInt("UpgradeCount", levelManagerScript.upgradeCount);
        PlayerPrefs.SetInt("PlayerLives", levelManagerScript.currentLives);
        PlayerPrefs.SetInt("PhaserBulletCount", playerGunScript.phaserBulletCount);
        PlayerPrefs.SetInt("ShieldChargeCount", playerRouterScript.shieldChargeCount);
        PlayerPrefs.SetInt("HasGun", tvPlayer.hasGun);
        PlayerPrefs.SetInt("HasVPN", tvPlayer.hasVPN);
        PlayerPrefs.SetInt("HasRouter", tvPlayer.hasRouter);

        yield return new WaitForSeconds(1.3f);

        SceneManager.LoadScene(levelToLoad);
    }
}
