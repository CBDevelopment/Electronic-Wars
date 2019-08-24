using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite Lightoff;
    public Sprite Lighton;

    private Evolve evolveScript;
    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;

    public bool checkpointActive;

    private SpriteRenderer theSpriteRenderer;

    public Collider2D theColliderBox;
    public GameObject checkPointSplosion;

	// Use this for initialization
	void Start () {

        theSpriteRenderer = GetComponent<SpriteRenderer>();
        theColliderBox.enabled = true;
        evolveScript = FindObjectOfType<Evolve>();
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
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
            //evolveScript.Transform();
            tvPlayer.respawnPosition = this.transform.position;
            plasmaPlayer.respawnPosition = this.transform.position;
            Instantiate(checkPointSplosion, this.transform.position, this.transform.rotation);

        }
    }
}
