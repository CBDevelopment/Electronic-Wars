using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFlip : MonoBehaviour
{
    public GameObject theNPC;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = theNPC.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            spriteRenderer.flipX = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.flipX = false;

    }

}
