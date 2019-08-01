using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour
{

    private LevelManager theLevelManager;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private Boss boss1;

    public GameObject upgradeBreak;

    public int upgradeValue;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
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
            theLevelManager.AddUpgrade(upgradeValue);
            Instantiate(upgradeBreak, this.transform.position, this.transform.rotation);
            gameObject.SetActive(false);

            if (theLevelManager.upgradeCount == 1)
            {
                //This is turned off on the BossScript
                boss1.TutorialHolder.SetActive(true);
            }
        }

        
    }
}
