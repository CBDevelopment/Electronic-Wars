using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour
{

    private LevelManager theLevelManager;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;

    public GameObject upgradeBreak;

    public int upgradeValue;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
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
        }
    }
}
