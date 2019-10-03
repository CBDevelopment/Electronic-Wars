using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotionController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;

    public LevelManagerNetwork levelManagerNetworkScript;

    public bool canMove;

    public Transform landingPoint;

    public void Start() // Upper case because in C# casing counts!
    {
        //rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        canMove = true;
    }

    public void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");

        //// Let's assign both x and z
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.velocity = (movement * speed);
    }

    public void Update()
    {
        MovePlayerX();
        MovePlayerY();
    }

    public void MovePlayerY()
    {
        if (canMove)
        {
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                Vector3 temp = transform.position;
                temp.y += speed * Time.deltaTime;

                transform.position = temp;
            }
            else if (Input.GetAxisRaw("Vertical") < 0f)
            {
                Vector3 temp = transform.position;
                temp.y -= speed * Time.deltaTime;

                transform.position = temp;
            }
        }
    }

    public void MovePlayerX()
    {
        if (canMove)
        {


            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;

                transform.position = temp;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                Vector3 temp = transform.position;
                temp.x -= speed * Time.deltaTime;

                transform.position = temp;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            levelManagerNetworkScript.StartCoroutine("RespawnIE");
        }
    }

    //public void OnCollisionEnter2D(Collision other)
    //{
    //    if(other.gameObject.tag == "Enemy")
    //    {
    //        levelManagerNetworkScript.StartCoroutine("RespawnIE");

    //    }
    //}

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            this.transform.position = this.transform.position;

        }
    }
}
