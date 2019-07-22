using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPosition : MonoBehaviour {

    //private PlasmaPlayer plasmaPlayer;

    //public Vector3 tvPosition;
    //public Vector3 plasmaPosition;
    //private Evolve evolveScript;

    //Use this for initialization

    public float speed;
    private Transform target;


    public Vector3 pos;

    void Start() {


        //tvPlayer = FindObjectOfType<PlayerController>();

        //plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        //evolveScript = FindObjectOfType<Evolve>();
    }

    // Update is called once per frame
    void Update () {

        pos = transform.position;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}
