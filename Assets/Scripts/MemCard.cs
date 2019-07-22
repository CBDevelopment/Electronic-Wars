using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemCard : MonoBehaviour {

    private LevelManager theLevelManager;

    public GameObject membreak;
    public PlayerController tvPlayer;
    public PlasmaPlayer plasmaPlayer;

    public int memValue;

	// Use this for initialization
	void Start () {

        theLevelManager = FindObjectOfType<LevelManager>();
        tvPlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    //Colliding with Memory Cards
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theLevelManager.AddMemory(memValue);
            Instantiate(membreak, this.transform.position, this.transform.rotation);
            //Destroy(gameObject.gameObject);
            gameObject.SetActive(false);
        }

    }
}
