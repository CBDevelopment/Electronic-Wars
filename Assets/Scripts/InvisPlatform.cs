using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
