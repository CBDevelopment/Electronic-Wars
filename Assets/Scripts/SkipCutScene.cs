using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutScene : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theMainCamera;
    public GameObject theLevelMusic;
    private StartCutScene startCutSceneScript;
    public Collider2D theCutSceneTrigger;
    public GameObject theCutScene;

    // Start is called before the first frame update
    void Start()
    {
        startCutSceneScript = FindObjectOfType<StartCutScene>();
        theCutSceneTrigger = startCutSceneScript.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && startCutSceneScript.videoActive)
        {
            theCutScene.SetActive(false);
            thePlayer.SetActive(true);
            theMainCamera.SetActive(true);
            theCutSceneTrigger.enabled = false;
            theLevelMusic.SetActive(true);
        }
    }
}
