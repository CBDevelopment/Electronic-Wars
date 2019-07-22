using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherController : MonoBehaviour {

    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D myRigibody2D;

	// Use this for initialization
	void Start () {
        myRigibody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove)
        {
            myRigibody2D.velocity = new Vector3(-moveSpeed, myRigibody2D.velocity.y, 0f);
        }
	}

    void OnBecameVisible()
    {
        canMove = true;
    }
}
