using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;
    private LevelManager levelManagerScript;

    public GameObject theCutScene;
    public bool videoActive;
    public GameObject thePlayer;
    public Collider2D theCollider;
    public GameObject theMainCamera;
    public GameObject levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        videoActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (videoActive)
        {

        }



    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theCutScene.SetActive(true);
            videoActive = true;
            theCollider.enabled = false;
        }
    }
}
