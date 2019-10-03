using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlue : MonoBehaviour
{
    public GameObject[] dialogs;
    private PlayerController tvPlayer;
    public Transform dialogPos;
    public GameObject theNPC;
    public AudioSource talkFX;
    public Animator anim;
    private LevelManager levelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        anim = gameObject.GetComponent<Animator>();
        anim = theNPC.gameObject.GetComponent<Animator>();
        levelManagerScript = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && levelManagerScript.upgradeCount >= 0)
        {

            //You may need to create this animation for the NPC game object character.
            anim.SetBool("Talking", true);
            Instantiate(dialogs[0], dialogPos.position, dialogPos.rotation);
            talkFX.Play();
        }

        //if (other.tag == "Player" && levelManagerScript.upgradeCount <= 3 && tvPlayer.hasVPN ==0)
        //{

        //    //You may need to create this animation for the NPC game object character.
        //    anim.SetBool("Talking", true);
        //    Instantiate(dialogs[0], dialogPos.position, dialogPos.rotation);
        //    talkFX.Play();
        //}

        //if (other.tag == "Player" && levelManagerScript.upgradeCount == 3 && tvPlayer.hasVPN==1)
        //{

        //    anim.SetBool("Talking", true);
        //    Instantiate(dialogs[1], dialogPos.position, dialogPos.rotation);
        //    talkFX.Play();
        //}
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
}
