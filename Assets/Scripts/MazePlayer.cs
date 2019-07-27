using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayer : MonoBehaviour
{
    public float maxSpeed = 5;
    public float speed = 150f;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Move left & right controls
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            rb2d.AddForce(Vector2.right * speed);
        }

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            rb2d.AddForce(Vector2.left * speed);

        }

        //Move up and down
        if (Input.GetKey("Vertical"))

        {
            rb2d.AddForce(Vector2.up * speed);
        }

    }


}
