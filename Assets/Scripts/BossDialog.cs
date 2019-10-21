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
    private PlayerController tvPlayer;
    public AudioSource DialogFX;
    private Draw drawScript;


    // Start is called before the first frame update
    void Start()
    {
        talkIndex = 1;
        madTabScript = FindObjectOfType<MadTab>();
        tvPlayer = FindObjectOfType<PlayerController>();
        drawScript = FindObjectOfType<Draw>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            entirePlayer.gameObject.SetActive(false);
            theDialogUI.gameObject.SetActive(true);

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

            //
            //
            //
            //
            //ADD ADDITIONAL BOSS SCRIPTS HERE.
            madTabScript.bossActive = true;
            //drawScript.bossActive = true;
            //next boss here
            //next boss here
            //next boss here
            //etc.
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
