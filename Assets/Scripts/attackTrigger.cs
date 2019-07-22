using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    public int dmg;

    public GameObject destroySplosion;

    private EnemyHealth theEnemyHealthScript;

    private void Start()
    {
        theEnemyHealthScript = FindObjectOfType<EnemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //other.transform.parent.GetComponent<EnemyHealth>().takeDamage = true;
            //theEnemyHealthScript.currentHealth -= 1;
            Instantiate(destroySplosion, other.transform.position, other.transform.rotation);
        }

        if(other.tag == "Boss")
        {
            other.transform.parent.GetComponent<Boss>().takeDamage = true;
            Instantiate(destroySplosion, other.transform.position, other.transform.rotation);

        }

    }
}
