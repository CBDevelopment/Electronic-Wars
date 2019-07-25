using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{

    public GameObject shopScreenUI;
    //Reference these buttons when you want to programtically toggle the interactions with the buttons
    //under certain contraints.
    public GameObject PhaserBuyButton;
    public GameObject SimBuyButton;
    public GameObject Dialog;
    //public GameObject ExtraLifeDialog;
    public GameObject phaserUI;
    public GameObject extraLifeUI;
    public GameObject simCardUI;
    public GameObject shieldChargesUI;
    public GameObject purchaseBreak;

    public int shopUISelect = 1;

    public AudioSource purchaseSound;
    public AudioSource insufficientSound;
    public AudioSource closeSound;
    public AudioSource arrowSound;
   
    public bool shopOpen = false;
    private PlayerController tvPlayer;
    private PlayerGun playerGunScript;
    private LevelManager levelManagerScript;
    private PlayerRouter playerRouterScript;


    // Start is called before the first frame update
    void Start()
    {
        shopScreenUI.SetActive(false);
        Dialog.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        levelManagerScript = FindObjectOfType<LevelManager>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();
    }

    // Update is called once per frame
    void Update()
    {

        //THE SHOP OPTION SELECT UI
        if (shopOpen)
        {
            shopScreenUI.SetActive(true);

            if(shopUISelect == 1)
            {
                extraLifeUI.SetActive(true);

                phaserUI.SetActive(false);
                simCardUI.SetActive(false);
            }
            if(shopUISelect == 2)
            {
                phaserUI.SetActive(true);

                extraLifeUI.SetActive(false);
                simCardUI.SetActive(false);
            }
            if (shopUISelect == 3)
            {
                simCardUI.SetActive(true);

                extraLifeUI.SetActive(false);
                phaserUI.SetActive(false);

            }

            if(shopUISelect == 4)
            {
                shieldChargesUI.SetActive(true);

                simCardUI.SetActive(false);
                extraLifeUI.SetActive(false);
                phaserUI.SetActive(false);
            }

        }

        if (!shopOpen)
        {
            shopScreenUI.SetActive(false);
        }

       

        //checking for if the player has the phaser gun. If so, they can buy bullets for the phaser gun.
        if (tvPlayer.hasGun == 1)
        {
            PhaserBuyButton.GetComponent<Button>().interactable = true;
        }
        if(tvPlayer.hasGun == 0)
        {
            PhaserBuyButton.GetComponent<Button>().interactable = false;
        }

        //Checking if player has sim. Disable the button if you've bought the SIM. Only 1 SIM card is needed to power the shield. 

        if (tvPlayer.hasSIM == 1)
        {
            SimBuyButton.GetComponent<Button>().interactable = false;
        }
        else if (tvPlayer.hasSIM == 0)
        {
            SimBuyButton.GetComponent<Button>().interactable = true;
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
        if(levelManagerScript.memCount >= 100)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 100;
            playerGunScript.phaserBulletCount += 5;
            Instantiate(purchaseBreak, playerGunScript.phaserBulletText.transform.position, playerGunScript.phaserBulletText.transform.rotation);


        }

        else if(levelManagerScript.memCount < 100)
        {
            insufficientSound.Play();
            Dialog.SetActive(true);

        }
    }

    public void BuyExtraLife()
    {
        if (levelManagerScript.memCount >= 75)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 75;
            levelManagerScript.currentLives ++;
            Instantiate(purchaseBreak, levelManagerScript.livesText.transform.position, levelManagerScript.livesText.transform.rotation);
        }

        else if (levelManagerScript.memCount < 75)
        {
            insufficientSound.Play();
            Dialog.SetActive(true);

        }
    }

    public void BuySIM()
    {
        //Do the purchase function here and call it when necessary.
        if (levelManagerScript.memCount >= 250)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 250;
            //reference the shield charges button here.EnterCode here to enable the button.
            tvPlayer.hasSIM = 1;
        }

        else if (levelManagerScript.memCount < 250)
        {
            insufficientSound.Play();
            Dialog.SetActive(true);

        }

    }

    public void BuyShieldCharges()
    {
        if (levelManagerScript.memCount >= 500 && tvPlayer.hasRouter == 1 && tvPlayer.hasSIM == 1)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 500;
            playerRouterScript.shieldChargeCount += 5;
            Instantiate(purchaseBreak, playerRouterScript.shieldChargeText.transform.position, playerRouterScript.shieldChargeText.transform.rotation);
        }

        else if (levelManagerScript.memCount < 500)
        {
            insufficientSound.Play();
            Dialog.SetActive(true);

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
        Dialog.SetActive(false);

        if(shopUISelect == 1)
        {
            shopUISelect = 2;
        }
        else if (shopUISelect == 2)
        {
            shopUISelect = 3;
        }
        else if (shopUISelect == 3)
        {
            shopUISelect = 4;
        }

    }

    public void LeftArrow()
    {
        arrowSound.Play();
        Dialog.SetActive(false);

        if (shopUISelect == 4)
        {
            shopUISelect = 3;
        }

        else if (shopUISelect == 3)
        {
            shopUISelect = 2;
        }

        else if (shopUISelect == 2)
        {
            shopUISelect = 1;
        }
    }
}
