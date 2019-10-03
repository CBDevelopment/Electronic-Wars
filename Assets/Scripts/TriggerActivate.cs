using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{

    private MadTab madTabScript;
    private BossDialog bossDialogScript;
    private LevelManager levelManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        madTabScript = FindObjectOfType<MadTab>();
        bossDialogScript = FindObjectOfType<BossDialog>();
        levelManagerScript = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //madTabScript.bossActive = true;
            bossDialogScript.isTalking = true;
            levelManagerScript.levelMusic.Stop();
            //Test this down below. Make sure that if you've encountered the boss 1 time, the UI will pop up

        }
    }
}
