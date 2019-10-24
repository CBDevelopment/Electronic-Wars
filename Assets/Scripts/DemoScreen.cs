using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScreen : MonoBehaviour
{

    public string levelToLoad;
    public float levelTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;

        if(levelTimer <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
