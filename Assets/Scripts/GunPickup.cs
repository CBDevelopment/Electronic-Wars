using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    public Image slot1Image;

    private PlayerController tvPlayerScript;

    public GameObject gunPickUp;

    private PlayerGun playerGunScript;

    // Start is called before the first frame update
    void Start()
    {
        tvPlayerScript = FindObjectOfType<PlayerController>();
        playerGunScript = FindObjectOfType<PlayerGun>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" | other.tag == "AttackTrigger" && tvPlayerScript.hasGun == 0)
        {
            tvPlayerScript.hasGun = 1; //Sets to True using int value of 1.
            playerGunScript.phaserBulletCount = 10;

            Instantiate(gunPickUp, this.transform.position, this.transform.rotation);


            slot1Image.gameObject.SetActive(true);

            Destroy(gameObject);

        }
    }
}
