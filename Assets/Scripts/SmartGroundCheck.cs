using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartGroundCheck : MonoBehaviour
{

    private SmartPlayer smartPlayer;
    //private SmartPlayer smartPlayerScript;

    void Start()
    {
        smartPlayer = gameObject.GetComponentInParent<SmartPlayer>();
        //smartPlayerScript = FindObjectOfType<SmartPlayer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        smartPlayer.grounded = true;
        //smartPlayer.GetComponent<Rigidbody2D>().gravityScale = 5;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        smartPlayer.grounded = true;
        //smartPlayer.GetComponent<Rigidbody2D>().gravityScale = 5;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        smartPlayer.grounded = false;

    }

}
