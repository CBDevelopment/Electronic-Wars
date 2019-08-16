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
    public GameObject ShieldBuyButton;
    public GameObject vpnBuyButton;
    public GameObject Dialog;
    public GameObject ShieldsMessage;
    public GameObject VPNMessage;
    public GameObject SIMCardMessage;
    public GameObject vpnHUDImage;
    //public GameObject ExtraLifeDialog;
    public GameObject phaserScreen;
    public GameObject extraLifeScreen;
    public GameObject simCardScreen;
    public GameObject shieldChargesScreen;
    public GameObject vpnScreen;
    public GameObject purchaseBreak;
    public Collider2D registerColliderBox;

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
    private PlasmaPlayer plasmaPlayer;
    private TransformationCloud transformationCloudScript;

    // Start is called before the first frame update
    void Start()
    {
        shopScreenUI.SetActive(false);
        Dialog.SetActive(false);
        ShieldsMessage.SetActive(false);
        VPNMessage.SetActive(false);
        vpnHUDImage.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();
        playerGunScript = FindObjectOfType<PlayerGun>();
        levelManagerScript = FindObjectOfType<LevelManager>();
        playerRouterScript = FindObjectOfType<PlayerRouter>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        transformationCloudScript = FindObjectOfType<TransformationCloud>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //THE SHOP OPTION SELECT UI
        if (shopOpen)
        {
            shopScreenUI.SetActive(true);
            //tvPlayer.canMove = false;
            //plasmaPlayer.canMove = false;


            if (shopUISelect == 1)
            {
                extraLifeScreen.SetActive(true);

                phaserScreen.SetActive(false);
                simCardScreen.SetActive(false);
                shieldChargesScreen.SetActive(false);
                vpnScreen.SetActive(false);
            }
            if(shopUISelect == 2)
            {
                phaserScreen.SetActive(true);

                extraLifeScreen.SetActive(false);
                simCardScreen.SetActive(false);
                shieldChargesScreen.SetActive(false);
                vpnScreen.SetActive(false);

            }
            if (shopUISelect == 3)
            {
                simCardScreen.SetActive(true);

                extraLifeScreen.SetActive(false);
                phaserScreen.SetActive(false);
                shieldChargesScreen.SetActive(false);
                vpnScreen.SetActive(false);

            }

            if (shopUISelect == 4)
            {
                shieldChargesScreen.SetActive(true);

                simCardScreen.SetActive(false);
                extraLifeScreen.SetActive(false);
                phaserScreen.SetActive(false);
                vpnScreen.SetActive(false);

            }

            if (shopUISelect == 5)
            {
                vpnScreen.SetActive(true);

                shieldChargesScreen.SetActive(false);
                simCardScreen.SetActive(false);
                extraLifeScreen.SetActive(false);
                phaserScreen.SetActive(false);
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
            SIMCardMessage.SetActive(false);
            SimBuyButton.GetComponent<Button>().interactable = false;
            ShieldBuyButton.GetComponent<Button>().interactable = true;
        }
        else if (tvPlayer.hasSIM == 0)
        {
            SIMCardMessage.SetActive(true);
            SimBuyButton.GetComponent<Button>().interactable = true;
            ShieldBuyButton.GetComponent<Button>().interactable = false;

        }


        //Checking if the player has a VPN.
        if (tvPlayer.hasVPN == 1)
        {
            vpnBuyButton.GetComponent<Button>().interactable = false;
            vpnHUDImage.SetActive(true);

        }

        if(tvPlayer.hasRouter == 0)
        {
            SimBuyButton.GetComponent<Button>().interactable = false;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            //shopOpen = true;
            //if (Input.GetButtonDown("Attack"))
            //{
            //    shopOpen = true;

            //}

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Could also work around this by doing a 
            //check of TV's position between the position of the register then call the shop UI)
            //shopOpen = true;
            shopOpen = true;
            tvPlayer.canMove = false;
            transformationCloudScript.canTransform = false;
            //registerColliderBox.enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Close();
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
        if (levelManagerScript.memCount >= 25)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 25;
            tvPlayer.hasSIM = 1;
            Instantiate(purchaseBreak, SimBuyButton.transform.position, SimBuyButton.transform.rotation);
            ShieldsMessage.SetActive(true);
        }

        else if (levelManagerScript.memCount < 25)
        {
            insufficientSound.Play();
            Dialog.SetActive(true);

        }

    }

    public void BuyVPN()
    {
        //Do the purchase function here and call it when necessary.
        if (levelManagerScript.memCount >= 250)
        {
            purchaseSound.Play();
            levelManagerScript.memCount -= 250;
            tvPlayer.hasVPN = 1;
            Instantiate(purchaseBreak, vpnHUDImage.transform.position, vpnHUDImage.transform.rotation);
            VPNMessage.SetActive(true);
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
        registerColliderBox.enabled = true;
        tvPlayer.canMove = true;
        transformationCloudScript.canTransform = true;

        //tvPlayer.canMove = true;
        //plasmaPlayer.canMove = true;
    }

    public void RightArrow()
    {
        arrowSound.Play();
        Dialog.SetActive(false);
        ShieldsMessage.SetActive(false);
        VPNMessage.SetActive(false);

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

        else if (shopUISelect == 4)
        {
            shopUISelect = 5;
        }

    }

    public void LeftArrow()
    {
        arrowSound.Play();
        Dialog.SetActive(false);
        ShieldsMessage.SetActive(false);
        VPNMessage.SetActive(false);

        if (shopUISelect == 5)
        {
            shopUISelect = 4;
        }

        else if (shopUISelect == 4)
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
