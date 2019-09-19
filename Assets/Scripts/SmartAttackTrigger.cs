using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartAttackTrigger : MonoBehaviour
{

    public int dmg;

    public GameObject destroySplosion;

    private EnemyHealth theEnemyHealthScript;

    public void Start()
    {
        theEnemyHealthScript = FindObjectOfType<EnemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            //Instantiate(destroySplosion, other.transform.position, other.transform.rotation);
        }

        if (other.tag == "Boss")
        {
            other.transform.parent.GetComponent<Boss>().takeDamage = true;
            //Instantiate(destroySplosion, other.transform.position, other.transform.rotation);

        }

    }
}
