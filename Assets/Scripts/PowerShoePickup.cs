using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerShoePickup : MonoBehaviour
{

    public Image slot3Image;

    private PlayerController tvPlayerScript;

    public GameObject powerShoePickup;

    //private PlayerPowerShoe playerPowerShoe;

    // Start is called before the first frame update
    void Start()
    {
        tvPlayerScript = FindObjectOfType<PlayerController>();
        //playerPowerShoe = FindObjectOfType<PlayerPowerShoe>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" | other.tag == "AttackTrigger" && tvPlayerScript.hasPowerShoe == 0)
        {
            tvPlayerScript.hasPowerShoe = 1; //Sets to True using int value of 1.
            //playerRouterScript.shieldChargeCount = 1;

            Instantiate(powerShoePickup, this.transform.position, this.transform.rotation);

            slot3Image.gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }
}
