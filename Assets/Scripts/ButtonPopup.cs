using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPopup : MonoBehaviour
{

    public GameObject buttonMessage;

    // Start is called before the first frame update
    void Start()
    {
        buttonMessage.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            buttonMessage.GetComponent<SpriteRenderer>().enabled = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonMessage.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
