using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public bool canFollow;

    private PlayerController tvPlayer;
    private LevelManager levelManagerScript;

	// Use this for initialization
	void Start () {

        tvPlayer = FindObjectOfType<PlayerController>();
        levelManagerScript = FindObjectOfType<LevelManager>();
        canFollow = true;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Moves camera across axis
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        if (canFollow)
        {
            transform.position = new Vector3(posX, posY, transform.position.z);

            if(levelManagerScript.upgradeCount == 0)
            {
                if (tvPlayer.facingLeft)
                {
                    smoothTimeX = 0;
                    smoothTimeY = .2f;
                }
                else
                {
                    smoothTimeX = 0f;
                    smoothTimeY = .2f;

                }
            }

            if(levelManagerScript.upgradeCount == 1)
            {
                if (tvPlayer.facingLeft)
                {
                    smoothTimeX = .2f;
                    smoothTimeY = .2f;
                }
                else
                {
                    smoothTimeX = 0.2f;
                    smoothTimeY = .2f;
                }
            }
        }

            if (bounds)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                    Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                    Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            }
        }
    }
