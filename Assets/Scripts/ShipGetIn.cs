using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipGetIn : MonoBehaviour
{
    public string levelToLoad;
    public Animator anim;
    public GameObject entirePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                entirePlayer.gameObject.SetActive(false);
                anim.SetBool("Flying", true);
                Invoke("StartNextLevel", 4f);
            }
        }
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
