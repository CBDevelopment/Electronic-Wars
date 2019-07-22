using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossLevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public PlayerController thePlayer;

    public GameObject deathBreak;

    public int memCount;

    public Text memText;

    private bool respawning;

    public ResetOnRespawn[] objectsToReset;

    public int currentLives;
    public int startingLives;
    public Text livesText;

    public GameObject gameOverScreen;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource gameoverMusicAddition;



    // Use this for initialization
    void Start()
    {
        

        thePlayer = FindObjectOfType<PlayerController>();
        memText.text = "0" + memCount;

        currentLives = startingLives;
        livesText.text = "x " + currentLives;

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
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
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameoverMusicAddition.Play();
            gameOverMusic.Play();
        }

    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        Instantiate(deathBreak, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);


        thePlayer.transform.position = thePlayer.respawnPosition;

        thePlayer.gameObject.SetActive(true);

        //reset objects in game.
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }

        //sets health back to full on respawn

        thePlayer.currentHealth = thePlayer.maxHealth;
    }

    public void AddMemory(int memToAdd)
    {
        memCount += memToAdd;
        memText.text = "0" + memCount;

    }

    public void AddLives(int livestoAdd)
    {
        currentLives += livestoAdd;
        livesText.text = "x " + currentLives;

    }

}
