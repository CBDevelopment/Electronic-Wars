using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOff : MonoBehaviour
{
    public SpriteRenderer theSpriteRenderer;
    public BoxCollider2D theBlockCollider;

    // Start is called before the first frame update
    void Start()
    {
        theSpriteRenderer.enabled = false;
        theBlockCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theSpriteRenderer.enabled = true;
            theBlockCollider.enabled = true;
        }
    }

    public void BlockOff()
    {
        theSpriteRenderer.enabled = true;
        theBlockCollider.enabled = true;

    }

    public void ResetBlockOff()
    {
        theSpriteRenderer.enabled = false;
        theBlockCollider.enabled = false;
    }
}
