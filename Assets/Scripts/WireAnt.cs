using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAnt : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    void Update()
    {


        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {


            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        }
    }

    //public void Damage (int damage)
    //{
    //    gameObject.GetComponent<Animation>().Play("Flash");
    //}
}
