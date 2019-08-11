using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    //private string levelToLoad = "Level1House";
    //private float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;

        //if(timer <= 0)
        //{
        //    SceneManager.LoadScene("Level1House");

        //}
    }

    public void OnEnable()
    {
        SceneManager.LoadScene("Level1House");
    }
}
