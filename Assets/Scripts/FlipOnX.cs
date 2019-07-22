using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOnX : MonoBehaviour {

    public SpriteRenderer theSpriteRenderer;

    public Boss theboss;


    // Use this for initialization
    void Start () {

        theSpriteRenderer = GetComponent<SpriteRenderer>();
        theboss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update () {

        //if (theboss.takeDamage)
        //{
        //    theSpriteRenderer.flipX = true;
        //}


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //if (other.tag == "AttackTrigger")

        //{
        //    theSpriteRenderer.flipX = true;
        //}
        
    }

}
