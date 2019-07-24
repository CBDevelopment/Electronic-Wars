using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{

    public GameObject shopScreenUI;
    public bool shopOpen = false;
    private PlayerController tvPlayer;


    // Start is called before the first frame update
    void Start()
    {
        shopScreenUI.SetActive(false);
        tvPlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (shopOpen)
        {
            shopScreenUI.SetActive(true);
            
        }

        if (!shopOpen)
        {
            shopScreenUI.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("Attack"))
            {
                shopOpen = true;
            }

        }
    }

    public void Buy()
    {
        //Do the math of a purchase here.
    }

    public void Close()
    {
        shopOpen = false;
    }
}
