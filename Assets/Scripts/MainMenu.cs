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
    public GameObject continueButton;
    //public GameObject purchaseBreak;
    //public Transform newGameButtonPos;
    //public Transform continueButtonPos;


    // Use this for initialization
    void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
        levelManagerScript = FindObjectOfType<LevelManager>();

        //Load If Game Has Been Played Before
        if (PlayerPrefs.HasKey("GameHasBeenPlayed"))
        {

            levelManagerScript.GameHasBeenPlayed = PlayerPrefs.GetInt("GameHasBeenPlayed");
            continueButton.gameObject.SetActive(true);
        }
        //else
        //{
        //    continueButton.gameObject.SetActive(false);

        //}

    }

    // Update is called once per frame
    void Update () {

        if (levelManagerScript.GameHasBeenPlayed == 0)
        {
            continueButton.gameObject.SetActive(false);
        }

        if (levelManagerScript.GameHasBeenPlayed == 1)
        {
            continueButton.gameObject.SetActive(true);
        }
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
        PlayerPrefs.SetInt("MaxHealth", 3);
        PlayerPrefs.SetInt("HasDoneFirstServerMission", 0);
        PlayerPrefs.SetInt("GameHasBeenPlayed", 0); //sets the value after the tutorial has been completed.
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
