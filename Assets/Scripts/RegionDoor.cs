using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegionDoor : MonoBehaviour {

    public bool open;
    public bool closed;

    public Animator anim;

    public string levelToLoad;

    public bool locked;

    private PlayerController tvPlayer;

    // Use this for initialization
    void Start() {

        tvPlayer = FindObjectOfType<PlayerController>();

        //Sets level 1 to always be a value of 1/true.
        PlayerPrefs.SetInt("Level1", 1);

        //Checks if the level to load has a value of 1/true.
        if (PlayerPrefs.GetInt(levelToLoad) == 1)
        {
            locked = false;
        }
        else
        {
            locked = true;
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {

        if (locked)
        {
            anim.SetBool("Locked", true);
        }
        else { anim.SetBool("Locked", false);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //    if (other.tag == "Player" && !locked)
        //    {

        //        anim.SetBool("Open", true);
        //    }
        //else {
        //    anim.SetBool("Open", false);
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && !locked)
        {
            anim.SetBool("Open", false);
            anim.SetBool("Close", true);
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        anim.SetBool("Open", true);

        if (other.tag == "Player")
        {
            if (Input.GetAxisRaw("Vertical") > 0f && !locked)
            {
                //SceneManager.LoadScene(levelToLoad);
                StartCoroutine(StartLevel());
            }
        }
    }

    public IEnumerator StartLevel()
    {
        tvPlayer.anim.SetBool("EnteringDoor", true);
        tvPlayer.transform.position = this.transform.position;

        yield return new WaitForSeconds(1.26f);
        tvPlayer.anim.SetBool("EnteringDoor", false);
        SceneManager.LoadScene(levelToLoad);
    }
}
