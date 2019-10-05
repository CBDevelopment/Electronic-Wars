using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialog : MonoBehaviour
{
    public GameObject[] bossParts;
    public GameObject[] teevParts;
    public int talkIndex = 0;
    public bool isTalking = false;
    public GameObject theDialogUI;
    public GameObject entirePlayer;
    private MadTab madTabScript;

    // Start is called before the first frame update
    void Start()
    {
        talkIndex = 1;
        madTabScript = FindObjectOfType<MadTab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking && talkIndex < 3)
        {
            //talkIndex = 1;
            theDialogUI.gameObject.SetActive(true);
            entirePlayer.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Jump") && talkIndex ==1 && isTalking)
        {
            teevParts[0].gameObject.SetActive(true);
            StartCoroutine(TalkIndex1());
        }

        if (Input.GetButtonDown("Jump") && talkIndex == 2 && isTalking)
        {
            teevParts[0].gameObject.SetActive(false);
            bossParts[0].gameObject.SetActive(false);
            bossParts[1].gameObject.SetActive(true);
            StartCoroutine(TalkIndex2());
        }

        if (Input.GetButtonDown("Jump") && talkIndex >= 3 && isTalking)
        {
            isTalking = false;
            theDialogUI.gameObject.SetActive(false);
            entirePlayer.gameObject.SetActive(true);
            madTabScript.bossActive = true;
        }

    }

    public IEnumerator TalkIndex1()
    {
        yield return new WaitForSeconds(.1f);
        talkIndex=2;
    }

    public IEnumerator TalkIndex2()
    {
        yield return new WaitForSeconds(.1f);
        talkIndex=3;
    }
}
