using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StoreExit : MonoBehaviour
{

    private LevelEnd levelEndScript;

    public string levelToLoad;

    void Start()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelEndScript.LevelEndCo();
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
