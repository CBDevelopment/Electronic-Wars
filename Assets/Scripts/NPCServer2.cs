using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCServer2 : MonoBehaviour
{
    public GameObject dialogUI;
    public BoxCollider2D SecondDialogTrigger;
    public GameObject entirePlayer;
    public AudioSource talkFX;
    public GameObject[] serverParts;
    public GameObject[] teevParts;
    public bool isTalking = false;
    public AudioSource memoryGiveFX;
    public GameObject MemorySplosion;
    public int talkIndex = 0;


    //Mission Selection Objects
    //public GameObject buttonHighlight1;
    //public GameObject buttonHighlight2;

    private NPCServer firstNpcServerScript;
    private LevelManager levelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        firstNpcServerScript = FindObjectOfType<NPCServer>();
        levelManagerScript = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstNpcServerScript.hasMission)
        {
            SecondDialogTrigger.enabled = true;
        }
        else
        {
            SecondDialogTrigger.enabled = false;
        }

        if (isTalking)
        {
            entirePlayer.gameObject.SetActive(false);

            if (Input.GetButtonDown("Jump") && levelManagerScript.memCount < 100 && talkIndex == 0)
            {
                Close();
            }

            if (Input.GetButtonDown("Jump") && levelManagerScript.memCount >= 100 && talkIndex ==0)
            {
                GiveMemory();
                StartCoroutine(ServerSecondIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 1)
            {
                //display next message.
                serverParts[1].gameObject.SetActive(false);
                serverParts[2].gameObject.SetActive(true);
                StartCoroutine(ServerThirdIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 2)
            {
                //display next message.
                //serverParts[2].gameObject.SetActive(false);
                //put whatever response you want after Server's info about the generator.
                StartCoroutine(TeevSecondIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 3)
            {
                //display next message.
                serverParts[2].gameObject.SetActive(false);
                serverParts[3].gameObject.SetActive(true);
                //put whatever response you want after Server's info about the generator.
                StartCoroutine(ServerFourthIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 4)
            {
                //display next message.
                teevParts[2].gameObject.SetActive(false);
                StartCoroutine(TeevThirdIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 5)
            {
                //display next message.
                serverParts[3].gameObject.SetActive(false);
                serverParts[4].gameObject.SetActive(true);
                StartCoroutine(ServerFithIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 6)
            {
                //display next message.
                teevParts[3].gameObject.SetActive(false);
                StartCoroutine(TeevFourthIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 7)
            {
                //display next message.
                serverParts[4].gameObject.SetActive(false);
                serverParts[5].gameObject.SetActive(true);
                StartCoroutine(ServerSixthIE());
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 8)
            {
                Close();
            }
        }
        else
        {
            entirePlayer.gameObject.SetActive(true);    
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //entirePlayer.gameObject.SetActive(false);
        dialogUI.gameObject.SetActive(true);
        talkFX.Play();
        serverParts[0].gameObject.SetActive(true);
        isTalking = true;

        if (levelManagerScript.memCount < 100)
        {
            StartCoroutine(TeevIE());
        }

        if (levelManagerScript.memCount >= 100)
        {
            teevParts[0].gameObject.SetActive(false);
            teevParts[1].gameObject.SetActive(true);
            isTalking = true;
        }
    }

    public IEnumerator TeevIE()
    {

        yield return new WaitForSeconds(.3f);
        teevParts[0].gameObject.SetActive(true);

        //isTalking = false;
        //Close();
    }

    public IEnumerator ServerSecondIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 1;

    }

    public IEnumerator ServerThirdIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 2;

    }

    public IEnumerator TeevSecondIE()
    {

        yield return new WaitForSeconds(.1f);
        teevParts[2].gameObject.SetActive(true);
        talkIndex = 3;
    }

    public IEnumerator ServerFourthIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 4;

    }

    public IEnumerator TeevThirdIE()
    {

        yield return new WaitForSeconds(.1f);
        teevParts[3].gameObject.SetActive(true);
        talkIndex = 5;
    }

    public IEnumerator ServerFithIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 6;

    }
    public IEnumerator TeevFourthIE()
    {
        yield return new WaitForSeconds(.1f);
        teevParts[4].gameObject.SetActive(true);
        talkIndex = 7;
    }

    public IEnumerator ServerSixthIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 8;

    }

    public void GiveMemory()
    {
        teevParts[1].gameObject.SetActive(false);
        serverParts[0].gameObject.SetActive(false);
        firstNpcServerScript.hasMission = false;
        firstNpcServerScript.missionMessage.gameObject.SetActive(false);

        levelManagerScript.memCount -= 100;
        memoryGiveFX.Play();
        Instantiate(MemorySplosion, dialogUI.transform.position, dialogUI.transform.rotation);
        serverParts[1].gameObject.SetActive(true);
        StartCoroutine(ServerSecondIE());
    }

    public void Close()
    {
        dialogUI.gameObject.SetActive(false);
        isTalking = false;

    }
}
