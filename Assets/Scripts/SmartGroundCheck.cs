using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartGroundCheck : MonoBehaviour
{

    private SmartPlayer smartPlayer;

    void Start()
    {
        smartPlayer = gameObject.GetComponentInParent<SmartPlayer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        smartPlayer.grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        smartPlayer.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        smartPlayer.grounded = false;

    }
}
