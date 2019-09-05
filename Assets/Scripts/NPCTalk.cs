using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public GameObject[] dialogs;
    private PlayerController tvPlayer;
    //public bool talking = false;
    public Transform dialogPos;
    public GameObject theNPC;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        anim = gameObject.GetComponent<Animator>();
        anim = theNPC.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            //You may need to create this animation for the NPC game object character.
            anim.SetBool("Talking", true);
            Instantiate(dialogs[Random.Range(0, dialogs.Length)], dialogPos.position, dialogPos.rotation);

        }

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
