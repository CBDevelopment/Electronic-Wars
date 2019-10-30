using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate3 : MonoBehaviour
{

    private BossDialog3 bossDialogScript3;
    private LevelManager levelManagerScript;
    private Draw drawScript;

    // Start is called before the first frame update
    void Start()
    {
        bossDialogScript3 = FindObjectOfType<BossDialog3>();
        drawScript = FindObjectOfType<Draw>();
        levelManagerScript = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //madTabScript.bossActive = true;

            ////Test to make sure the boss activates after you have landed on the top level.
            levelManagerScript.levelMusic.Stop();
            StartCoroutine(bossActivate());
            StartCoroutine(FXTurnOff());
        }
    }

    public IEnumerator bossActivate()
    {
        yield return new WaitForSeconds(.5f);
        if (drawScript.playerHasDiedOnce == 0)
        {
            bossDialogScript3.DialogFX.Play();
            bossDialogScript3.isTalking = true;
        }
        if (drawScript.playerHasDiedOnce == 1)
        {
            drawScript.bossActive = true;
        }

    }

    public IEnumerator FXTurnOff()
    {
        yield return new WaitForSeconds(3.5f);
        bossDialogScript3.DialogFX.gameObject.SetActive(false);

    }
}
