using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private Evolve evolveScript;
    private LevelManager levelManager;
    public float knockUpForce;
    //public float knockBackForce;


    public int damageToGive;

	// Use this for initialization
	void Start () {
        tvPlayer = FindObjectOfType<PlayerController>();
        evolveScript = gameObject.GetComponent<Evolve>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && tvPlayer.timeBetweenDamage <= 0)
        {

            tvPlayer.HurtPlayer(damageToGive);
            tvPlayer.timeBetweenDamage = 2f;
            tvPlayer.rb2d.velocity = new Vector3(-20f, knockUpForce, 0f);


            //StartCoroutine(tvPlayer.Knockback(.11f, 1, tvPlayer.transform.position));
            //StartCoroutine(plasmaPlayer.Knockback(.5f, 1, plasmaPlayer.transform.position));
            //thePlayer.Knockback();
            //thePlayer.HurtPlayer(damageToGive);

            //tvPlayer.Knockback(5f, 5, tvPlayer.transform.position);
            //plasmaPlayer.Knockback(0.5f, 5, plasmaPlayer.transform.position);


            //tvPlayer.Knockback();
            //plasmaPlayer.HurtPlayer(damageToGive);
        }
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        StartCoroutine(tvPlayer.Knockback(.5f, 1, tvPlayer.transform.position));
    //        //thePlayer.Knockback();
    //        //thePlayer.HurtPlayer(damageToGive);

    //        //tvPlayer.Knockback(0.5f, 5, tvPlayer.transform.position);
    //        //plasmaPlayer.Knockback(0.5f, 5, plasmaPlayer.transform.position);

    //        tvPlayer.HurtPlayer(damageToGive);
    //        plasmaPlayer.HurtPlayer(damageToGive);


    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        //StartCoroutine(tvPlayer.Knockback(0.1f, 1, tvPlayer.transform.position));
    //        tvPlayer.HurtPlayer(damageToGive);
    //        plasmaPlayer.HurtPlayer(damageToGive);

    //    }
    //}

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        tvPlayer.Knockback(0.5f, 5, tvPlayer.transform.position);
    //        plasmaPlayer.Knockback(0.5f, 5, plasmaPlayer.transform.position);

    //        tvPlayer.HurtPlayer(damageToGive);
    //        plasmaPlayer.HurtPlayer(damageToGive);
    //    }
    //}
}
