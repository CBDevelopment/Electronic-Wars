using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCServer : MonoBehaviour
{
    public GameObject[] dialogs;
    public GameObject entirePlayer;
    public Transform dialogPos;
    public GameObject theNPC;
    public AudioSource talkFX;
    public Animator anim;
    private LevelManager levelManagerScript;
    public GameObject dialogUI;
    public GameObject[] serverParts;
    public GameObject[] teevParts;
    //public GameObject nextButton;
    //public GameObject closeButton;
    public int hasTalkedOnce = 0;
    //public int teevPartSelect = 0;
    //public int serverPartSelect = 0;
    public GameObject missionMessage;
    public bool hasMission = false;
    public bool isTalking = false;
    public int talkIndex = 0;
    public BoxCollider2D FirstDialogTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //tvPlayer = FindObjectOfType<PlayerController>();
        anim = gameObject.GetComponent<Animator>();
        anim = theNPC.gameObject.GetComponent<Animator>();
        levelManagerScript = FindObjectOfType<LevelManager>();
        dialogUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (hasMission)
        //{
        //    missionMessage.gameObject.SetActive(true);

        //}
        //else
        //{
        //    missionMessage.gameObject.SetActive(false);
        //}

        if (hasTalkedOnce == 1)
        {
            FirstDialogTrigger.enabled = false;

        }

        if (isTalking)
        {
            entirePlayer.gameObject.SetActive(false);

            if (Input.GetButtonDown("Jump") && talkIndex == 1)
            {
                teevParts[0].gameObject.SetActive(true);
                StartCoroutine(TeevIE());
                //teevPartSelect = 1;
                //nextButton.gameObject.SetActive(true);
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 2)
            {
                serverParts[0].gameObject.SetActive(false);
                serverParts[1].gameObject.SetActive(true);

                StartCoroutine(ServerIE());
                //teevPartSelect = 1;
                //nextButton.gameObject.SetActive(true);
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 3)
            {
                serverParts[1].gameObject.SetActive(false);
                serverParts[2].gameObject.SetActive(true);

                StartCoroutine(ServerSecondIE());
                //teevPartSelect = 1;
                //nextButton.gameObject.SetActive(true);
            }

            if (Input.GetButtonDown("Jump") && talkIndex == 4)
            {
                CloseButton();
                //teevPartSelect = 1;
                //nextButton.gameObject.SetActive(true);
            }
        }
        else
        {
            entirePlayer.gameObject.SetActive(true);
        }

    }
    public IEnumerator TeevIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 2;

    }

    public IEnumerator ServerIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 3;

    }

    public IEnumerator ServerSecondIE()
    {

        yield return new WaitForSeconds(.1f);
        talkIndex = 4;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && levelManagerScript.upgradeCount <= 1)
        {
            //Disable the Player
            talkIndex = 1;
            //entirePlayer.gameObject.SetActive(false);
            //serverPartSelect = 1;
            hasTalkedOnce = 1;
            dialogUI.gameObject.SetActive(true);
            talkFX.Play();
            serverParts[0].gameObject.SetActive(true);
            isTalking = true;
        }

    }

    public void NextButton()
    {
        StartCoroutine(NextIE());

        //nextButton.gameObject.SetActive(false);
    }

    public void CloseButton()
    {
        StartCoroutine(CloseIE());

        isTalking = false;
        //entirePlayer.gameObject.SetActive(true);

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        ClearDialogs();
    }

    public void ClearDialogs()
    {
        GameObject[] dialogObjects = GameObject.FindGameObjectsWithTag("Dialog");
        foreach (GameObject gameObject in dialogObjects)
            GameObject.Destroy(gameObject);
        anim.SetBool("Talking", false);
    }

    public IEnumerator NextIE()
    {
        teevParts[0].gameObject.SetActive(false);
        serverParts[0].gameObject.SetActive(false);
        talkIndex++;

        yield return new WaitForSeconds(.3f);
        //serverPartSelect++;
        serverParts[1].gameObject.SetActive(true);
    }

    public IEnumerator CloseIE()
    {
        dialogUI.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.1f);
        hasMission = true;
    }
}
