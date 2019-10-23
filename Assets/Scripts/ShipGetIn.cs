using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipGetIn : MonoBehaviour
{
    public string levelToLoad;
    public Animator anim;
    public GameObject entirePlayer;
    public GameObject notification;
    private LevelManager levelManagerScript;
    private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!triggered)
        {
            if (levelManagerScript.upgradeCount == 3)
            {
                notification.gameObject.SetActive(true);
                triggered = true;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            notification.gameObject.SetActive(false);


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
