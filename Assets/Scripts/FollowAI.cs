using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    private bool canMove;
    //private PlasmaPlayer plasmaPlayer;

    //public Vector3 tvPosition;
    //public Vector3 plasmaPosition;
    //private Evolve evolveScript;

    //Use this for initialization

    public float speed;
    private Transform target;

    void Start()
    {


        //tvPlayer = FindObjectOfType<PlayerController>();

        //plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        //evolveScript = FindObjectOfType<Evolve>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

    }

    private void OnBecameVisible()
    {
        canMove = true;
    }

    private void OnBecameInvisible()
    {
        canMove = false;
    }
}
