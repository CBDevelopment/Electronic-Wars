using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRouter : MonoBehaviour
{
    public bool shielding = false;

    public float attackTimer;
    public float attackCD;

    //public Animator anim;
    public Collider2D routerTrigger;
    public GameObject theShield;

    private PlayerController tvPlayer;

    public AudioSource ShieldFX;

    public int shieldChargeCount;
    public Text shieldChargeText;


    // Start is called before the first frame update
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();

    }

    void Awake()
    {
        //anim = gameObject.GetComponent<Animator>();
        routerTrigger.enabled = false;
        theShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Show the remaining charges each time you fire.
        shieldChargeText.text = shieldChargeCount.ToString();

        if (Input.GetButtonDown("CastShield") && tvPlayer.hasRouter > 0 && shieldChargeCount > 0)
        {
            shielding = true;
            attackTimer = attackCD;
            routerTrigger.enabled = true;
            theShield.SetActive(true);
            ShieldFX.Play();
            shieldChargeCount--;
        }

        if (shielding)
        {

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                shielding = false;
                routerTrigger.enabled = false;
            }

            //anim.SetBool("Shielding", shielding);

        }

        if (Input.GetButtonUp("CastShield") && tvPlayer.hasRouter > 0)

        {
            routerTrigger.enabled = false;
            theShield.SetActive(false);
            shielding = false;

        }
    }
}
