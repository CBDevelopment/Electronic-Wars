using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{

    public GameObject shopScreenUI;
    public GameObject phaserBuyButton;
    public GameObject PhaserDialog;
    public GameObject ExtraLifeDialog;
    public GameObject phaserUI;
    public GameObject extraLifeUI;
    public GameObject purchaseBreak;

    public int shopIUSelect = 1;

    public AudioSource purchaseSound;
    public AudioSource insufficientSound;
    public AudioSource closeSound;
    public AudioSource arrowSound;
   
    public bool shopOpen = false;
    private PlayerController tvPlayer;
    private PlayerGun playerGunScript;
    private LevelManager levelManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        shopScreenUI.SetActive(false);
        PhaserDialog.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        levelManagerScript = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (shopOpen)
        {
            shopScreenUI.SetActive(true);
            if(shopIUSelect == 1)
            {
                phaserUI.SetActive(true);
                extraLifeUI.SetActive(false);
            }
            if(shopIUSelect == 2)
            {
                phaserUI.SetActive(false);
                extraLifeUI.SetActive(true);
            }
            
        }

        if (!shopOpen)
        {
            shopScreenUI.SetActive(false);
        }

       

        //checking for if the player has the phaser gun. If so, they can buy bullets for the phaser gun.
        if (tvPlayer.hasGun == 1)
        {
            phaserBuyButton.GetComponent<Button>().interactable = true;
        }
        if(tvPlayer.hasGun == 0)
        {
            phaserBuyButton.GetComponent<Button>().interactable = false;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("Attack"))
            {
                shopOpen = true;

            }


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopOpen = false;

        }
    }

    public void BuyBullets()
    {
        //Do the purchase function here and call it when necessary.
        if(levelManagerScript.memCount >= 50)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 50;
            playerGunScript.phaserBulletCount += 5;
            Instantiate(purchaseBreak, playerGunScript.phaserBulletText.transform.position, playerGunScript.phaserBulletText.transform.rotation);


        }

        else if(levelManagerScript.memCount < 50)
        {
            insufficientSound.Play();
            PhaserDialog.SetActive(true);

        }
    }

    public void BuyExtraLife()
    {
        if (levelManagerScript.memCount >= 100)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 100;
            levelManagerScript.currentLives ++;
            Instantiate(purchaseBreak, levelManagerScript.livesText.transform.position, levelManagerScript.livesText.transform.rotation);
        }

        else if (levelManagerScript.memCount < 50)
        {
            insufficientSound.Play();
            PhaserDialog.SetActive(true);

        }
    }

    public void Close()
    {
        closeSound.Play();
        shopOpen = false;
    }

    public void RightArrow()
    {
        arrowSound.Play();
        PhaserDialog.SetActive(false);

        if(shopIUSelect == 1)
        {
            shopIUSelect = 2;
        }  

    }

    public void LeftArrow()
    {
        arrowSound.Play();
        PhaserDialog.SetActive(false);

        if (shopIUSelect == 2)
        {
            shopIUSelect = 1;
        }

    }
}
