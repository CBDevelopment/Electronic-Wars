using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RouterPickup : MonoBehaviour
{

    public Image slot2Image;

    private PlayerController tvPlayerScript;

    public GameObject routerPickUp;

    private PlayerRouter playerRouterScript;

    // Start is called before the first frame update
    void Start()
    {
        tvPlayerScript = FindObjectOfType<PlayerController>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" | other.tag == "AttackTrigger" && tvPlayerScript.hasRouter == 0)
        {
            tvPlayerScript.hasRouter= 1; //Sets to True using int value of 1.
            playerRouterScript.shieldChargeCount = 1;

            Instantiate(routerPickUp, this.transform.position, this.transform.rotation);

            slot2Image.gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }
}
