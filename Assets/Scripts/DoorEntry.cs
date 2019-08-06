using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorEntry : MonoBehaviour
{
    public string levelToLoad;
    public GameObject doorEntry;
    // Start is called before the first frame update

    void Start()
    {
        //doorEntry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEntry.SetActive(true);

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEntry.SetActive(false);

        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Attack"))
            {
                SceneManager.LoadScene(levelToLoad);


            }
        }
    }
}
