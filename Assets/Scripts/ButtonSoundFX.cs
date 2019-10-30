using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundFX : MonoBehaviour
{

    public AudioSource moveButtonSoundFX;
    public AudioSource clickButtonSoundFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxisRaw("Horizontal") < -0.1f)
        //{
        //    moveButtonSoundFX.Play();
        //}

        //if (Input.GetAxisRaw("Horizontal") > 0.1f)
        //{
        //    moveButtonSoundFX.Play();
        //}

        if (Input.GetButtonDown("Vertical"))
        {
            moveButtonSoundFX.Play();
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            moveButtonSoundFX.Play();
        }

        if (Input.GetButtonDown("Submit"))
        {
            clickButtonSoundFX.Play();
        }
    }
}
