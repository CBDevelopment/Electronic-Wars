using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaPlayer : MonoBehaviour
{
    //Script References

    //Floats
    public float maxSpeed;
    public float speed;
    public float jumpPower;

    //Booleans
    public bool grounded;
    public bool canDoubleJump;
    public bool canMove;
    public bool onWall;

    //Player Stats
    public int currentHealth;
    public int maxHealth = 3;

    //References
    private Animator anim;
    private Rigidbody2D rb2d;

    public Vector3 respawnPosition;
    public LevelManager theLevelManager;
    private HurtPlayer hurtPlayerScript;

    //Sound Fx
    public AudioSource hurtSound;
    public AudioSource deathSound;

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
        //respawnPosition = transform.position;

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

        //tvPlayer = FindObjectOfType<PlayerController>();

        transform.position = lastPositionScript.pos;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        ////Gets position of the PlasmaPlayer
        //this.pos = transform.position;

        //FlipSprite On X; left and right.
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        //Don't move this or physics could be affected.
        currentHealth = tvPlayer.currentHealth;


        ////Checks for health and allows death.
        //if (currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}

        if (currentHealth <= 0)
        {

            theLevelManager.PlasmaRespawnCo();
            //GetComponent<Animation>().Play("Flash");
            Instantiate(theLevelManager.deathBreak, this.transform.position, this.transform.rotation);

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

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "KillPlane")
        {

            evolveScript.Transform();
        }

        //Resets you back to TV player if you hit a checkpoint.
        if (other.tag == "Checkpoint")
        {
            //evolveScript.Transform();
            //transformationCloudScript.GetComponent<Animator>().Play("Transforming");

        }


        if (other.tag == "Enemy")
        {
            //evolveScript.Transform();
            evolveScript.TransformToTeev();
            tvPlayer.HurtPlayer(hurtPlayerScript.damageToGive);

        }

        if (other.tag == "Boss")
        {
            evolveScript.Transform();
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

    //void Awake()
    //{
    //    canMove = true;
    //}

}
