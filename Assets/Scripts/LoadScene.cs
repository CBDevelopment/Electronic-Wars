using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{

    public string levelToLoad;
    private PlayerController tvPlayer;
    public Transform doorPos;

    public void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                //SceneManager.LoadScene(levelToLoad);
                StartCoroutine(StartLevel());
            }
        }
    }

    public IEnumerator StartLevel()
    {
        tvPlayer.anim.SetBool("EnteringDoor", true);
        tvPlayer.transform.position = doorPos.position;

        yield return new WaitForSeconds(1.26f);
        tvPlayer.anim.SetBool("EnteringDoor", false);
        SceneManager.LoadScene(levelToLoad);
    }

}
