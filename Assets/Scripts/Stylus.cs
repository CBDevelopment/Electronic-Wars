using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stylus : MonoBehaviour
{

    public float speed;
    //public float lifeTime;
    public float forwardTimer;
    public GameObject theStylus;
    public GameObject destroyEffect;//purchase particle affect.
    public GameObject damageSplosion;
    public AudioSource shootFX;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        forwardTimer -= Time.deltaTime;

        if(forwardTimer <= 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(transform.localScale.y, transform.localScale.y);

        }
        else
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        if(forwardTimer <= -4)
        {
            forwardTimer = 4;
            Destroy(theStylus);
        }
    }

    //void DestroyProjectile()
    //{
    //    //Instantiate(destroyEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "AttackTrigger")
        //{
        //    Destroy(gameObject);
        //    Instantiate(damageSplosion, this.transform.position, this.transform.rotation);

        //}

        //if (other.tag == "Player")
        //{
        //    Destroy(gameObject);
        //}

        //if (other.tag == "Shield")
        //{
        //    Instantiate(destroyEffect, transform.position, transform.rotation);
        //    Destroy(gameObject);

        //}
    }
}
