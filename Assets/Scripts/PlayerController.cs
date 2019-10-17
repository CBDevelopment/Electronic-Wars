using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    //Script References

    //Floats
    public float maxSpeed;
    public float speed;
    public float jumpPower;
    public float timeBetweenDamage = 1.4f;


    //Booleans
    public bool grounded;
    public bool canDoubleJump;
    //int bool
    public int doubleJumped = 0;
    public bool flipping;
    public bool hovering;
    public bool canMove;
    public bool onWall;
    public bool canJump;
    public bool canCrouch;

    //Player Stats
    public int currentHealth;
    public int maxHealth;

    //References
    public Animator anim;
    public Rigidbody2D rb2d;
    public Collider2D crouchCollider;
    //public Collider2D playerCollider;
    public Collider2D tvBodyCollider;

    public Vector3 respawnPosition;
    public LevelManager theLevelManager;

    //Sound Fx
    public AudioSource jumpSound;
    public AudioSource hurtSound;
    public AudioSource deathSound;
    public AudioSource runSound;
    public AudioSource meleeSound;

    //Special Bools ***********
    public int hasGun = 0;
    public int hasRouter = 0;
    public int hasPowerShoe = 0;
    public int hasSIM = 0;
    public int hasVPN = 0;
    public bool facingRight;
    public bool facingLeft;
    public bool crouch = false;

    //GameObject tv;
    //GameObject plasma;
    //int characterSelect;

    public Vector3 pos;

    private LastPosition lastPositionScript;
    private PlayerPowerShoe playerPowerShoeScript;
    private PlayerController thePlayerController;
    private Evolve evolveScript;
    private PlayerGun playerGun;
    private LevelEnd levelEndScript;
    private GunTutorialTrigger gunTutorialScript;

    void Start()
    {
        timeBetweenDamage = 0f;

        crouchCollider.enabled = false;
        //playerCollider.enabled = true;

        //Defaults to facing right.
        facingRight = true;

        //Enables mobility.
        canMove = true;
        canCrouch = true;

        //SpawnPoint
        respawnPosition = transform.position;

        //References to other scripts.
        theLevelManager = FindObjectOfType<LevelManager>();
        lastPositionScript = FindObjectOfType<LastPosition>();
        evolveScript = FindObjectOfType<Evolve>();
        thePlayerController = FindObjectOfType<PlayerController>();
        playerGun = FindObjectOfType<PlayerGun>();
        playerPowerShoeScript = FindObjectOfType<PlayerPowerShoe>();
        gunTutorialScript = FindObjectOfType<GunTutorialTrigger>(); 

        //Assign variables
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        //Start with full health 
        currentHealth = maxHealth;

        transform.position = lastPositionScript.pos;
    }

    // Update is called once per frame
    void Update()
    {


        timeBetweenDamage -= Time.deltaTime;
        pos = this.transform.position;

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));


        //Move left & right
        if (Input.GetAxisRaw("Horizontal") < -0f && canMove)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingLeft = true;
            facingRight = false;
        }

        if (Input.GetAxisRaw("Horizontal") > 0f && canMove)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingLeft = false;
            facingRight = true;

        }

        if (facingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        //Crouching
        //change this later to the following:
        if (Input.GetAxisRaw("Vertical") < 0f && canMove && canCrouch)
        {
            speed = 100;
            anim.SetBool("Crouching", true);
            //playerCollider.enabled = false;
            tvBodyCollider.enabled = false;
            crouchCollider.enabled = true;
        }

        else if (Input.GetAxis("Vertical") > 0f && canMove && canCrouch)
        {
            speed = 500;
            anim.SetBool("Crouching", false);
            //playerCollider.enabled = true;
            tvBodyCollider.enabled = true;
            crouchCollider.enabled = false;
        }

        //if (Input.GetButtonDown("Vertical") && canMove && canCrouch)
        //{
        //    speed = 100;
        //    anim.SetBool("Crouching", true);
        //    //playerCollider.enabled = false;
        //    tvBodyCollider.enabled = false;
        //    crouchCollider.enabled = true;
        //}

        if (Input.GetButtonUp("Vertical") && canMove && canCrouch)
        {
            speed = 500;
            anim.SetBool("Crouching", false);
            //playerCollider.enabled = true;
            tvBodyCollider.enabled = true;
            crouchCollider.enabled = false;
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && canMove)
        {
            if (grounded && !onWall)
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
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.25f);
                    jumpSound.Play();
                    anim.SetTrigger("Flipping");

                    if(hasPowerShoe == 1)
                    {
                        playerPowerShoeScript.powering = true;
                    }
                }
            }
        }
        //Checks for health and allows death.
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {

            theLevelManager.Respawn();
            gameObject.GetComponent<Animation>().Play("Flash");
            speed = 500;
            timeBetweenDamage = 1.4f;
        }

        if(timeBetweenDamage > 0)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().color.a = 0f;
            //anim.SetBool("Flashing", true);

        }

        if (timeBetweenDamage <= 0)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().color.a = 0f;
            //anim.SetBool("Flashing", false);
        }

        //Handle the upgrade and expandable Health.
        if(theLevelManager.upgradeCount == 2)
        {
            maxHealth = 4;
        }

        if (theLevelManager.upgradeCount == 3)
        {
            maxHealth = 5;
        }
        if (theLevelManager.upgradeCount == 4)
        {
            maxHealth = 6;
        }
        if (theLevelManager.upgradeCount == 5)
        {
            maxHealth = 7;
        }
        if (theLevelManager.upgradeCount == 6)
        {
            maxHealth = 8;
        }
        if (theLevelManager.upgradeCount == 7)
        {
            maxHealth = 9;
        }
        if (theLevelManager.upgradeCount == 8)
        {
            maxHealth = 10;
        }

    }


    void FixedUpdate()
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
                anim.SetBool("Flipping", false);
                doubleJumped = 0;
                playerPowerShoeScript.powering = false;

            }

            //Move Player
            rb2d.AddForce(Vector2.right * speed * h);

            //Limit Speed of left/right movement
            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

            }
            if (rb2d.velocity.x < -maxSpeed)
            {
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

            }
        }
    }

    //Receiving Damage
    public void HurtPlayer(int damageToTake)
    {
        currentHealth -= damageToTake;
        hurtSound.Play();
        GetComponent<Animator>().Play("Damaged");
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        canMove = false;
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * -13, knockbackDir.y * 3, transform.position.z));
        }
        canMove = true;

        yield return 0;

    }

    //Check player entering the kill plane trigger to kill
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "KillPlane")
        {
            //gameObject.SetActive(false);

            //transform.position = respawnPosition;

            theLevelManager.Respawn();
            speed = 500;

        }

        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }

        if (other.gameObject.tag == "Wall")
        {
            onWall = true;


        }
        else
        {

        }

        if (other.tag == "Gun")
        {
            gunTutorialScript.messageActive = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hoverboard")
        {
            rb2d.rotation = 0;
        }

        if (other.gameObject.tag == "Wall")
        {
            onWall = false;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;

            rb2d.rotation = 0;
        }

    }

    void OnEnable()
    {

        transform.position = lastPositionScript.pos;

    }

    public void RunSound()
    {
        runSound.Play();
    }

    //public void MeleeSound()
    //{
    //    meleeSound.Play();
    //}

}
