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
    public GameObject nextButton;
    public GameObject closeButton;
    public bool hasTalked = false;
    public int teevPartSelect = 0;
    public int serverPartSelect = 0;
    public GameObject missionMessage;
    public bool hasMission = false;
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
        if (hasMission)
        {
            missionMessage.gameObject.SetActive(true);
        }
        else
        {
            missionMessage.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Jump") && teevPartSelect ==0 && serverPartSelect ==1)
        {
            teevParts[0].gameObject.SetActive(true);
            teevPartSelect = 1;
            nextButton.gameObject.SetActive(true);
        }

        //-----Press the Next Button------//
        
        if (Input.GetButtonDown("Jump") && teevPartSelect ==1 && serverPartSelect == 2)
        {
            teevParts[1].gameObject.SetActive(true);
            teevPartSelect = 2;
            closeButton.gameObject.SetActive(true);
        }

        //-----Press the Close Button------//

        if (Input.GetButtonUp("Jump") && teevPartSelect ==2 && serverPartSelect == 2)
        {//incremented it up to 3 so i can press the same button to close the dialog
            teevPartSelect = 3;
        }
        if (Input.GetButtonDown("Jump") && teevPartSelect == 3 && serverPartSelect == 2)
        {
            CloseButton();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && levelManagerScript.upgradeCount <= 1)
        {
            //Disable the Player
            talkIndex = 1;
            entirePlayer.gameObject.SetActive(false);
            serverPartSelect = 1;
            hasTalked = true;
            dialogUI.gameObject.SetActive(true);
            talkFX.Play();
            serverParts[0].gameObject.SetActive(true);
            FirstDialogTrigger.enabled = false;
        }

    }

    public void NextButton()
    {
        StartCoroutine(NextIE());

        nextButton.gameObject.SetActive(false);
    }

    public void CloseButton()
    {
        StartCoroutine(CloseIE());

        entirePlayer.gameObject.SetActive(true);

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
        serverPartSelect++;
        serverParts[1].gameObject.SetActive(true);
    }

    public IEnumerator CloseIE()
    {
        dialogUI.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        hasMission = true;
    }
}
