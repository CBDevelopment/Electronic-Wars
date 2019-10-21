using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    private LevelManager levelManagerScript;
    private NPCBlue blueScript;
    private PlayerController tvPlayer;
    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManager>();
        blueScript = FindObjectOfType<NPCBlue>();
        tvPlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManagerScript.upgradeCount >= 3 && tvPlayer.hasVPN ==1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
