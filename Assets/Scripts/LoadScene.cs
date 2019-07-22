using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{

    public string levelToLoad;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButton("Attack"))
            {
                SceneManager.LoadScene(levelToLoad);

            }

        }

    }

}
