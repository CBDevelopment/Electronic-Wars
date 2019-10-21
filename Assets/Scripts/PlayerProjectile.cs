using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public Rigidbody2D rb;

    private PlayerController tvPlayer;

    public GameObject destroySplosion;

    //public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        tvPlayer = FindObjectOfType<PlayerController>();

        //if (tvPlayer.facingLeft)
        //{
        //    rb.velocity = -transform.right * speed;

        //}

        //if (tvPlayer.facingRight)
        //{
        //    rb.velocity = transform.right * speed;

        //}
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    private void Update()
    {
        //Move the projectile from left to --> right.
        //if (tvPlayer.facingRight)
        //{
        //}

        //if (tvPlayer.facingLeft)
        //{
        //    transform.Translate(-transform.right * speed * Time.deltaTime);

        //}
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);

        }

        if (other.tag == "Boss")
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            Instantiate(destroySplosion, other.transform.position, other.transform.rotation);
            //Destroy(gameObject);

        }
    }
}
