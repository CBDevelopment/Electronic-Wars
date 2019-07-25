using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRouter : MonoBehaviour
{
    public bool shielding = false;

    public float attackTimer = 3;
    public float attackCD = .38f;

    public Animator anim;
    public Collider2D routerTrigger;
    public GameObject theShield;

    private PlayerController tvPlayer;

    public AudioSource ShieldFX;

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
        if (Input.GetButtonDown("CastShield") && tvPlayer.hasRouter > 0)
        {
            shielding = true;
            attackTimer = attackCD;
            routerTrigger.enabled = true;
            theShield.SetActive(true);
            ShieldFX.Play();
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

            anim.SetBool("Shielding", shielding);

        }

        if (Input.GetButtonUp("CastShield") && tvPlayer.hasRouter > 0)

        {
            routerTrigger.enabled = false;
            theShield.SetActive(false);
            shielding = false;

        }
    }
}
