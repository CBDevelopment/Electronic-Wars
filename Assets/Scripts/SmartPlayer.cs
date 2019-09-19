using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPlayer : MonoBehaviour
{
    //Script References

    //Floats
    public float maxSpeed;
    public float speed;
    public float jumpPower;
    public float glideTime = 2.5f;

    //Booleans
    public bool grounded;
    public bool canMove;
    public bool facingRight;
    public bool facingLeft;
    public bool gliding;
    public bool canDoubleJump;

    //Player Stats
    public int currentHealth;
    public int maxHealth;
    public int blastAmount =1;
    public int doubleJumped =0;

    //References
    private Animator anim;
    public Rigidbody2D rb2d;


    public Vector3 respawnPosition;
    public LevelManager theLevelManager;
    private HurtPlayer hurtPlayerScript;

    public AudioSource jumpSound;
    public AudioSource hurtSound;
    public AudioSource blastSoundFX;


    //Sound Fx
    //public AudioSource hurtSound;
    //public AudioSource deathSound;

    //private PlayerController tvPlayer;

    public Vector3 pos;

    private LastPosition lastPositionScript;
    private Evolve evolveScript;
    private PlayerController tvPlayer;
    private Transform target;
    private TransformationCloud transformationCloudScript;

    void Start()
    {
        canMove = true;
        //SpawnPoint
        respawnPosition = transform.position;

        theLevelManager = FindObjectOfType<LevelManager>();
        lastPositionScript = FindObjectOfType<LastPosition>();
        evolveScript = FindObjectOfType<Evolve>();
        tvPlayer = FindObjectOfType<PlayerController>();
        transformationCloudScript = FindObjectOfType<TransformationCloud>();
        hurtPlayerScript = FindObjectOfType<HurtPlayer>();

        //Assign variables
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        //Start with full health
        currentHealth = maxHealth;
        //tvPlayer = FindObjectOfType<PlayerController>();

        transform.position = lastPositionScript.pos;
        facingRight = true;
        grounded = true;

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (gliding)
        {
            glideTime -= Time.deltaTime;
        }

        if (glideTime <= 0)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            glideTime = 2.5f;
        }

        ////Gets position of the PlasmaPlayer
        //this.pos = transform.position;

        //FlipSprite On X; left and right.
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingLeft = true;
            facingRight = false;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
            facingLeft = false;
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && canMove)

        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
                jumpSound.Play();
            }

            else
            {
                if (canDoubleJump)
                {
                    doubleJumped = 1;
                    canDoubleJump = false;
                    //StartCoroutine(ResetGravity()); //this is where the glide time is handled.
                    this.rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    StartCoroutine(GlidingIE()); //gliding=true;
                    anim.SetTrigger("Gliding");
                }
            }
        }

        if(Input.GetButtonDown("Jump") && gliding)
        {         
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                glideTime = 2.5f;
        }

        //Don't move this line or the physics may not work.
        currentHealth = tvPlayer.currentHealth;

        ////Checks for health and allows death.
        //if (currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}

        if (currentHealth <= 0)
        {
            theLevelManager.PlasmaRespawn();
            //GetComponent<Animation>().Play("Flash");
            Instantiate(theLevelManager.deathBreak, this.transform.position, this.transform.rotation);
        }

    }

    public void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 easeVelocity = rb2d.velocity;
            easeVelocity.y = rb2d.velocity.y;
            easeVelocity.z = 0.0f;
            easeVelocity.x *= 0.25f;

            float h = Input.GetAxis("Horizontal");

            //Friction Easing the x of player
            if (grounded)
            {
                rb2d.velocity = easeVelocity;
                anim.SetBool("Gliding", false);
                this.rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                gliding = false;
                glideTime = 2.5f;
            }

            //Move Player
            rb2d.AddForce(Vector3.right * speed * h);

            //Limit Speed of left/right movement
            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector3(maxSpeed, rb2d.velocity.y);

            }
            if (rb2d.velocity.x < -maxSpeed)
            {
                rb2d.velocity = new Vector3(-maxSpeed, rb2d.velocity.y);

            }
        }
    }


    public void OnEnable()
    {
        transform.position = lastPositionScript.pos;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        glideTime = 2.5f;

    }

    public IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(2.5f);
        //this.GetComponent<Rigidbody2D>().gravityScale = 5;
        //rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public IEnumerator GlidingIE()
    {
        yield return new WaitForSeconds(.1f);
        gliding = true;
    }
}
