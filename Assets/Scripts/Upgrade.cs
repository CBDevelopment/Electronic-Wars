using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour
{
    private PauseMenu pauseScript;
    private LevelManager theLevelManager;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private Boss boss1;

    public GameObject upgradeBreak;
    public int upgradeValue;
    //when you get an update, the route to leave the level should open up.
    public GameObject wallToRemove;


    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        pauseScript = FindObjectOfType<PauseMenu>();
        boss1 = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.upgradeCount = upgradeValue;
            //Use the below code in case there are issues with counting the upgrades.
            //theLevelManager.AddUpgrade(upgradeValue);
            Instantiate(upgradeBreak, this.transform.position, this.transform.rotation);
            gameObject.SetActive(false);

            if (theLevelManager.upgradeCount == 1)
            {
                //This is turned off on the BossScript
                boss1.TutorialHolder.SetActive(true);
                theLevelManager.tutorialMessageActive = true;
                boss1.upgradeMessageActive = true;
                //pauseScript.Pause();
            }
            //when you get an update, the route to leave the level should open up.
            //Cannot leave the level until you have collected the update.
            wallToRemove.gameObject.SetActive(false);
        }
    }
}
