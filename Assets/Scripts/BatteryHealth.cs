using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHealth : MonoBehaviour
{

    private LevelManager theLevelManager;

    public GameObject healthbreak;
    public PlayerController tvPlayer;
    public PlasmaPlayer plasmaPlayer;

    public int healthValue;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        tvPlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddHealth(healthValue);
            Instantiate(healthbreak, this.transform.position, this.transform.rotation);
            //Destroy(gameObject.gameObject);
            gameObject.SetActive(false);
        }
    }
}
