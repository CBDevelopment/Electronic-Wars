using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerWheel : MonoBehaviour
{

    public GameObject objectToMove; //the oil
    public Transform startPoint;
    public Transform endPoint;
    public Vector3 currentTarget;
    public float moveSpeed;

    public bool canMove;

    private CloseOff closeOffScript;

    public Animator anim;

    private PlayerController tvPlayer;

    public GameObject platformToEnable;

    public GameObject upArrow;

    public AudioSource sewerFX;

    // Start is called before the first frame update
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        closeOffScript = FindObjectOfType<CloseOff>();
        currentTarget = endPoint.position;
        objectToMove.transform.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

            if (objectToMove.transform.position == startPoint.position)
            {
                currentTarget = endPoint.position;

            }
        }

        if(tvPlayer.currentHealth <= 0)
        {
            //this.transform.position = startPoint.position;
            anim.SetBool("Turned", false);
            //closeOffScript.ResetBlockOff(); //Don't open the blockage back. Keep it blocked after attempting boss.
            canMove = false;
            upArrow.gameObject.SetActive(false);
            platformToEnable.gameObject.SetActive(false);

        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("Attack"))
            {
                //oil will start to move after the sewer wheel is triggered
                Invoke("OilCanFill", 2f);
                closeOffScript.BlockOff();
                anim.SetBool("Turned", true);
                platformToEnable.gameObject.SetActive(true);
                upArrow.gameObject.SetActive(true);
                sewerFX.Play();
            }
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AttackTrigger")
        {
            if (Input.GetButtonDown("Attack"))
            {
                //oil will start to move after the sewer wheel is triggered
                Invoke("OilCanFill", 2f);
                closeOffScript.BlockOff();
                anim.SetBool("Turned", true);
                platformToEnable.gameObject.SetActive(true);
                upArrow.gameObject.SetActive(true);
                sewerFX.Play();
            }
        }
    }

    public void OilCanFill()
    {
        canMove = true;
    }
}
