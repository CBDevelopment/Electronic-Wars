using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StoreExit : MonoBehaviour
{

    public string levelToLoad;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
                SceneManager.LoadScene(levelToLoad);
        }
    }
}
