using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorldMapButton : MonoBehaviour
{
    //public Animator anim;
    public int bIndex;
    public AudioSource moveButtonSoundFX;
    public AudioSource clickButtonSoundFX;

    // Start is called before the first frame update
    void Start()
    {
        //anim = FindObjectOfType<Animator>();
        bIndex = 1;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            moveButtonSoundFX.Play();
        }

 
        ///

      
        if (Input.GetButtonDown("Vertical"))
        {
             moveButtonSoundFX.Play();
        }
        

        if (Input.GetButtonDown("Submit"))
        {
            clickButtonSoundFX.Play();
        }

    }

    public void LoadNetworkTravelToPlains()
    {
        SceneManager.LoadScene("Network1");
    }

    public void LoadCityNetwork()
    {
        SceneManager.LoadScene("CityRegion");
    }
}
