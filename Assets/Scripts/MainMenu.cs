using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string firstLevel;
    public string levelSelect;
    public string[] levelNames;
    public int startingLives;
    private PlayerController tvPlayer;
    private LevelManager levelManagerScript;
    public GameObject blackScreen;
    public GameObject purchaseBreak;


    // Use this for initialization
    void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
        levelManagerScript = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

        //Loop levels to ensure the correct levels are reset.
        for(int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }

        //Resets all collectables.
        PlayerPrefs.SetInt("MemCount", 0);
        PlayerPrefs.SetInt("UpgradeCount", 0);
        PlayerPrefs.SetInt("PlayerLives", 3);
        PlayerPrefs.SetInt("MemCount", 0);
        PlayerPrefs.SetInt("UpgradeCount", 0);
        PlayerPrefs.SetInt("PhaserBulletCount", 0);
        PlayerPrefs.SetInt("HasGun", 0);
        PlayerPrefs.SetInt("HasRouter", 0);
        PlayerPrefs.SetInt("HasVPN", 0);
        PlayerPrefs.SetInt("ShieldChargeCount", 0);

    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
