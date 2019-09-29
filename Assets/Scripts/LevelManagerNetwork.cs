using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerNetwork : MonoBehaviour
{
    public int currentLives;

    public AudioSource levelMusic;

    //public GameObject gameOverScreen;

    public GameObject headphonePlayer;

    public GameObject deathBreak;

    public float waitToRespawn;

    public Transform respawnPosition;

    private string thisLevel = "Network1";

    public float levelTime;

    private Network1Boss theNetworkBoss;
    private ShipMotionController headphoneShipPlayer;

    public GameObject theBoss;

    //public bool bossDied = false;

    public GameObject networkWorld;

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        theNetworkBoss = FindObjectOfType<Network1Boss>();
        headphoneShipPlayer = FindObjectOfType<ShipMotionController>();
    }

    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        if (levelTime <= 0)
        {
            theBoss.gameObject.SetActive(true);
            //theNetworkBoss.bossActive = true;
        }

    }

    public IEnumerator RespawnIE()
    {
        currentLives -= 1;

        headphonePlayer.gameObject.SetActive(false);
        Instantiate(deathBreak, headphonePlayer.transform.position, headphonePlayer.transform.rotation);

        //levelMusic.Stop();

        yield return new WaitForSeconds(1.5f);

        //headphonePlayer.transform.position = respawnPosition.transform.position;
        //headphonePlayer.gameObject.SetActive(true);
        SceneManager.LoadScene(thisLevel);
    }
}
