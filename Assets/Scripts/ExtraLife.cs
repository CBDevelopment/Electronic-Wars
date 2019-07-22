using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour {

    public int livesToGive;
    public LevelManager theLevelManager;
    public GameObject extraBreak;
    private PlayerController thePlayer;



    // Use this for initialization
    void Start () {

        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theLevelManager.AddLives(livesToGive);
            gameObject.SetActive(false);
            Instantiate(extraBreak, this.transform.position, this.transform.rotation);

        }
    }
}
