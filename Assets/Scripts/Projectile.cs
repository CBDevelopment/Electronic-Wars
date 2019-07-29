using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;

    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
   private void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "AttackTrigger")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Shield")
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
