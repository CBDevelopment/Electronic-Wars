using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerNetwork : MonoBehaviour
{
    public int currentLives;

    public AudioSource levelMusic;

    //public GameObject gameOverScreen;

    public GameObject headphonePlayer;

    public GameObject deathBreak;

    public float waitToRespawn;

    public Transform respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator RespawnIE()
    {
        currentLives -= 1;

        headphonePlayer.gameObject.SetActive(false);
        Instantiate(deathBreak, headphonePlayer.transform.position, headphonePlayer.transform.rotation);

        levelMusic.Stop();

        yield return new WaitForSeconds(1.5f);

        headphonePlayer.transform.position = respawnPosition.transform.position;
        headphonePlayer.gameObject.SetActive(true);
    }
}
