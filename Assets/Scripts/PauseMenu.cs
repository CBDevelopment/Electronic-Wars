using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    private PlayerController tvPlayer;

    private LevelManager levelManagerScript;

    public string levelToLoad;

    private void Start()
    {
        PauseUI.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();
        levelManagerScript = FindObjectOfType<LevelManager>(); 
    }

    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            //Keeps you from jumping while paused (fixed glitch)
            tvPlayer.grounded = false;
            
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void Play()
    {
        paused = false;
    }

    //public void Pause()
    //{
        
    //}

    //public void UnPause()
    //{

    //}

    //[System.Obsolete]
    public void GameOverRestart()
    {
        SceneManager.LoadScene(levelToLoad);
        PlayerPrefs.SetInt("PlayerLives", 3);

        //SceneManager.GetActiveScene();

    }

    //[System.Obsolete]
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        //levelManagerScript.currentLives = PlayerPrefs.GetInt("PlayerLives");


        ////SceneManager.GetActiveScene();

    }


    public void Quit()
    {
        Application.Quit();
    }
}
