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
            StartCoroutine(bossActivate());
        }
    }

    public IEnumerator bossActivate()
    {
        yield return new WaitForSeconds(1f);
        bossDialogScript.isTalking = true;
    }
}
