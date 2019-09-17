using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerShoe : MonoBehaviour
{
    public bool powering = false;

    //public float attackTimer;
    //public float attackCD;

    //public Animator anim;
    public Collider2D powerShoeTrigger;
    public GameObject thePower;

    private PlayerController tvPlayer;

    public AudioSource PowerFX;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    //private Rigidbody2D tvPlayerRigidbody;
    public float bounceForce;

    //public int shieldChargeCount;
    //public Text shieldChargeText;


    // Start is called before the first frame update
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        anim = thePower.gameObject.GetComponent<Animator>();
        spriteRenderer = thePower.gameObject.GetComponent<SpriteRenderer>();
        //tvPlayerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
        spriteRenderer.enabled = false;
    }

    void Awake()
    {
        //anim = gameObject.GetComponent<Animator>();
        //powerShoeTrigger.enabled = false;
        //thePower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Show the remaining charges each time you fire.
        //shieldChargeText.text = shieldChargeCount.ToString();

        //if (Input.GetButtonDown("Jump") && tvPlayer.hasPowerShoe ==1 && tvPlayer.doubleJumped ==1)
        //{
        //    powering = true;
        //    //thePower.SetActive(true);
        //    //anim.Play("Powering");

        //    //PowerFX.Play();
        //    //shieldChargeCount--;
        //}

        //if (tvPlayer.grounded)
        //{
        //    powering = false;
        //}

        if (powering)
        {
            powerShoeTrigger.enabled = true;
            spriteRenderer.enabled = true;
        }

        if(!powering)
        {
            powerShoeTrigger.enabled = false;
            spriteRenderer.enabled = false;

        }

        //if (powering)
        //{

        //    if (attackTimer > 0)
        //    {
        //        attackTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        shielding = false;
        //        routerTrigger.enabled = false;
        //    }

        //    //anim.SetBool("Shielding", shielding);

        //}

        //if (Input.GetButtonUp("CastShield") && tvPlayer.hasRouter > 0)

        //{
        //    routerTrigger.enabled = false;
        //    theShield.SetActive(false);
        //    shielding = false;

        //}
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && powering)
        {
            //tvPlayer.rb2d.AddForce(Vector3.up * bounceForce);
            tvPlayer.rb2d.velocity = new Vector3(tvPlayer.rb2d.velocity.x, bounceForce, 0f);

        }
    }
}
