using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticlePlatform : MonoBehaviour
{

    private PlatformEffector2D theEffector;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        theEffector = GetComponent<PlatformEffector2D>();
        theEffector.rotationalOffset = 0f;
        waitTime = 0.05f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //waitTime = 0.1f;
            theEffector.rotationalOffset = 0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(waitTime < 0)
            {
                theEffector.rotationalOffset = 180f;
                //waitTime = 0.1f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    theEffector.rotationalOffset = 0f;
        //}
    }
}
