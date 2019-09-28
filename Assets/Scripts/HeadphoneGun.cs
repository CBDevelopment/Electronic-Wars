using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeadphoneGun : MonoBehaviour
{
    //private bool firing = false;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public AudioSource shotFX;

    //private Animator anim;

    //private PlayerController tvPlayer;
    //private PlayerProjectile playerProjectile;
    //private LevelManager theLevelManager;
    //public float timeBetweenShots;
    //private float shotCount;

    // Use this for initialization
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        //tvPlayer = FindObjectOfType<PlayerController>();
        //playerProjectile = FindObjectOfType<PlayerProjectile>();
    }

    void Awake()
    {
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetButtonDown("Attack")) //&& theLevelManager.phaserBulletCount < 0)
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBetweenShots = startTimeBetweenShots;
                shotFX.Play();
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
            //anim.Play("Firing");
        }

    }


}
