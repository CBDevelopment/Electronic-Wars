using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverboard : MonoBehaviour {

    public bool canMove;

    public GameObject objectToMove;
    public Transform endPoint;

    public float moveSpeed;

    private Vector3 currentTarget;

    // Use this for initialization
    void Start()
    {

        currentTarget = endPoint.position;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canMove = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canMove = false;
        }
    }

    void Update()
    {
        if(canMove)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
            
            if (objectToMove.transform.position == endPoint.position)
            {
            }

        }
        
    }
}

