using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    public int dmg;
    public GameObject damageSplosion;
    private EnemyHealth theEnemyHealthScript;

    public void Start()
    {
        theEnemyHealthScript = FindObjectOfType<EnemyHealth>();
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if(theEnemyHealthScript.currentHealth > 0)
            {
                Instantiate(damageSplosion, other.transform.position, other.transform.rotation);
            }
        }

        if(other.tag == "Boss")
        {
            other.transform.parent.GetComponent<Boss>().takeDamage = true;
            //Instantiate(destroySplosion, other.transform.position, other.transform.rotation);

        }

    }
}
