using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public AudioSource shotFX;
    private bool canHearShots;

    private PlayerController tvPlayer;

    //public float timeBetweenShots;
    //private float shotCount;
    
    // Use this for initialization
    void Start()
    {
        canHearShots = false;
        tvPlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
   private void Update()
    {

        
        //if (shotCount > 0)
        //{
        //    shotCount -= Time.deltaTime;
        //}

        //else
        //{
        //    //startPoint.position = new Vector3(startPoint.position.y, startPoint.position.z);
        //    Instantiate(theProjectile, startPoint.position, startPoint.rotation);
        //    shotCount = timeBetweenShots;
        //}

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
            timeBetweenShots = startTimeBetweenShots;

            if (canHearShots)
            {
                shotFX.Play();

            }

        }
        else
        {
            timeBetweenShots -= Time.deltaTime; 
        }

    }

    private void OnBecameVisible()
    {
        canHearShots = true;
    }

    private void OnBecameInvisible()
    {
        canHearShots = false;
    }
}
