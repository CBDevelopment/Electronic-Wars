using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite Lightoff;
    public Sprite Lighton;

    public bool checkpointActive;

    private SpriteRenderer theSpriteRenderer;

    public Collider2D theColliderBox;

	// Use this for initialization
	void Start () {

        theSpriteRenderer = GetComponent<SpriteRenderer>();
        theColliderBox.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            theSpriteRenderer.sprite = Lighton;
            checkpointActive = true;
            theColliderBox.enabled = false;
        }
    }
}
