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

            ////Test to make sure the boss activates after you have landed on the top level.
            levelManagerScript.levelMusic.Stop();
            if(madTabScript .playerHasDiedOnce == 0)
            {
                StartCoroutine(bossFirstActivate());
                StartCoroutine(FXTurnOff());
            }

            if (madTabScript.playerHasDiedOnce == 1)
            {
                madTabScript.bossDialogTrigger.enabled = false;
                madTabScript.bossActive = true;
                //StartCoroutine(resetTrigger());
            }

        }
    }

    public IEnumerator bossFirstActivate()
    {
        yield return new WaitForSeconds(0f);
 
            bossDialogScript.DialogFX.Play();
            bossDialogScript.isTalking = true;
    }

    public IEnumerator FXTurnOff()
    {
        yield return new WaitForSeconds(3.5f);
        bossDialogScript.DialogFX.gameObject.SetActive(false);
    }

    //public IEnumerator resetTrigger()
    //{
    //    yield return new WaitForSeconds(.1f);
    //    madTabScript.bossDialogTrigger.enabled = false;
    //}
}
