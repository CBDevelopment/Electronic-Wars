using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWallJump : MonoBehaviour {

    private PlayerController tvPlayer;


	// Use this for initialization
	void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        
    }

    void OnTriggerEnter2D(Collider other)
    {
        if(other.tag == "Player")
        {
            tvPlayer.canJump = false;
        }
    }
}
