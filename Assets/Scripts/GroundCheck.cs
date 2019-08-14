using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerController player;
    public GameObject landingSplosion;
    public Transform landingPoint;
    public Transform landingPoint2;

    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
        Instantiate(landingSplosion, landingPoint.position, landingPoint.rotation);
        Instantiate(landingSplosion, landingPoint2.position, landingPoint2.rotation);

    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}
