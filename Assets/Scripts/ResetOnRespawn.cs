using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespawn : MonoBehaviour {

    private Vector3 startPosition;
    private Quaternion startRotataion;
    private Vector3 startLocalScale;

    private Rigidbody2D myRigidbody;

    private EnemyHealth theEnemyHealthScript;


	// Use this for initialization
	void Start () {

        startPosition = transform.position;
        startRotataion = transform.rotation;
        startLocalScale = transform.localScale;

        theEnemyHealthScript = FindObjectOfType<EnemyHealth>();

        if (GetComponent<Rigidbody2D>() != null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetObject()
    {
        transform.position = startPosition;
        transform.rotation = startRotataion;
        transform.localScale = startLocalScale;

        if (myRigidbody != null)
        {
            myRigidbody.velocity = Vector3.zero;
        }
    }
}
