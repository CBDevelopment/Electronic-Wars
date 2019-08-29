using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkipOpeningCutscene : MonoBehaviour
{
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nextLevel);

        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(nextLevel);

        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(nextLevel);

        }
    }
}
