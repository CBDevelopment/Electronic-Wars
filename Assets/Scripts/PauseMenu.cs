using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    private PlayerController tvPlayer;

    private void Start()
    {
        PauseUI.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
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

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
