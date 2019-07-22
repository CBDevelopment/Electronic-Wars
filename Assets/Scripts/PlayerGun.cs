using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    //private bool firing = false;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public AudioSource shotFX;

    private Animator anim;

    private PlayerController tvPlayer;
    private PlayerProjectile playerProjectile;
    private LevelManager theLevelManager;
    public int phaserBulletCount;
    public Text phaserBulletText;

    //public float timeBetweenShots;
    //private float shotCount;

    // Use this for initialization
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        tvPlayer = FindObjectOfType<PlayerController>();
        playerProjectile = FindObjectOfType<PlayerProjectile>();
    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Show the remaining bullets each time you fire.
        phaserBulletText.text = phaserBulletCount.ToString();

        if (Input.GetButtonDown("Fire") && tvPlayer.hasGun > 0 && phaserBulletCount > 0) //&& theLevelManager.phaserBulletCount < 0)
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBetweenShots = startTimeBetweenShots;
                shotFX.Play();
                phaserBulletCount--;
            }
            else
            {
                    timeBetweenShots -= Time.deltaTime;
            }
            anim.Play("Firing");
        }
        
    }


}
