using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluggyAnimation : MonoBehaviour {

    private Animator anim;

    private Boss theBossScript;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        theBossScript = FindObjectOfType<Boss>();
	}
	
	// Update is called once per frame
	void Update () {

        if (theBossScript.bossActive)
        {
            //anim.SetBool("Attacking", true);
            //else { anim.SetBool("Attacking", true);
            //    anim.SetBool("Teleporting", false);
            //}
        }
    }
		
	
}
