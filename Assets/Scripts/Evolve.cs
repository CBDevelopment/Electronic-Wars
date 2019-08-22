using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{

    public GameObject tv;
    public GameObject plasma;
    public int characterSelect;
    public bool isTV;
    public bool isPlasma;

    private PlasmaPlayer plasmaPlayer;
    private PlayerController tvPlayer;
    private LevelManager levelManagerScript;

    // Use this for initialization
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        levelManagerScript = FindObjectOfType<LevelManager>();
        characterSelect = 1;
        plasmaPlayer.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        plasmaPlayer.pos = tvPlayer.pos;

        //if (Input.GetButtonUp("Transform"))
        //{
        //    Transform();
        //}
    }

    public void Transform() {


            if (characterSelect == 1 && levelManagerScript.upgradeCount >= 1)
            {
                characterSelect = 2;

            }
            else if (characterSelect == 2)
            {
                characterSelect = 1;

            }

            if (characterSelect == 1 && levelManagerScript.upgradeCount >= 1)
            {
                tv.SetActive(true);
                isTV = true;
                isPlasma = false;
                plasma.SetActive(false);

            }

            else if (characterSelect == 2)
            {

                tv.SetActive(false);
                plasma.SetActive(true);
                isPlasma = true;
                isTV = false;

            }
        
    }
}
