using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public int fullHealth;

    public int dropRate;

    public GameObject itemToDrop;
    public GameObject healthBarObject;

    //public Slider healthBar.  

    public Sprite[] healthBarSprites;
    private Shake shakeCamera;

    public GameObject destroySplosion;
    public GameObject damageSplosion;

    // Start is called before the first frame update
    void Start()
    {
        shakeCamera = FindObjectOfType<Shake>(); 
        fullHealth = startingHealth;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Displays HealthBar and changes the healthbar image based on enemies current health.
        if (currentHealth == 8)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[7];
        }
        if (currentHealth == 7)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[6];
        }
        if (currentHealth == 6)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[5];
        }
        if (currentHealth == 5)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[4];
        }
        if (currentHealth == 4)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[3];
        }
        if (currentHealth == 3)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[2];
        }
        if (currentHealth == 2)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[1];
        }
        if (currentHealth == 1)
        {
            healthBarObject.GetComponent<SpriteRenderer>().sprite = this.healthBarSprites[0];
        }
        //***********************************************************************************

        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            Instantiate(destroySplosion, this.transform.position, this.transform.rotation);

            if (Random.Range(0,3) == dropRate)
            {
                Instantiate(itemToDrop, this.transform.position, this.transform.rotation);
            }

            currentHealth = startingHealth;
        }

    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "AttackTrigger")
        {
            currentHealth -= 1;
            shakeCamera.CamShake();

            if(currentHealth > 0)
            {
                Instantiate(damageSplosion, this.transform.position, this.transform.rotation);

            }

        }

        if (other.tag == "Bullet")
        {
            //Destroy(other.gameObject);
            currentHealth -= 1;
            shakeCamera.CamShake();

            if (currentHealth > 0)
            {
                Instantiate(damageSplosion, this.transform.position, this.transform.rotation);

            }

        }
    }
}
