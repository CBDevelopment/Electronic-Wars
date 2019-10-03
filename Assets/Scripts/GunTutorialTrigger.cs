using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTutorialTrigger : MonoBehaviour
{
    public BoxCollider2D gunTriggerBox;
    public GameObject gunTutorial;
    public bool messageActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (messageActive)
        {
            if (Input.GetButtonDown("Jump"))
            {
                gunTutorial.gameObject.SetActive(false);
            }

            if (Input.GetButtonDown("Fire"))
            {
                gunTutorial.gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gunTutorial.gameObject.SetActive(true);
            gunTriggerBox.enabled = false;
            messageActive = true;
        }
    }
}
