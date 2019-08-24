using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Exception : MonoBehaviour
{

    private LevelManager levelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Update")
        {
            if(levelManagerScript.upgradeCount > 1)
            {
                levelManagerScript.upgradeCount = 1;
            }
        }
    }

}
