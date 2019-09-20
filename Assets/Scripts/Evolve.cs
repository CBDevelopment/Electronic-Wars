using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{

    public GameObject tv;
    public GameObject plasma;
    public GameObject smart;
    public int characterSelect;
    public bool isTV;
    public bool isPlasma = false;
    public bool isSmart = false;

    private PlasmaPlayer plasmaPlayer;
    private PlayerController tvPlayer;
    private SmartPlayer smartPlayer;
    private LevelManager levelManagerScript;
    private TransformationCloud transformationCloudScript;
    private LastPosition lastPositionScript;

    // Use this for initialization
    void Start()
    {
        tvPlayer = FindObjectOfType<PlayerController>();
        plasmaPlayer = FindObjectOfType<PlasmaPlayer>();
        smartPlayer = FindObjectOfType<SmartPlayer>();

        levelManagerScript = FindObjectOfType<LevelManager>();
        transformationCloudScript = FindObjectOfType<TransformationCloud>();
        lastPositionScript = FindObjectOfType<LastPosition>();
        characterSelect = 1;
        plasmaPlayer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        plasmaPlayer.pos = lastPositionScript.pos;
        smartPlayer.pos = lastPositionScript.pos;

        //if (Input.GetButtonUp("Transform"))
        //{
        //    Transform();
        //}
    }

    public void Transform() {
        //switch (characterSelect)
        //{
        //    case 1:
        //        characterSelect = 2;
        //        break;
        //    case 2:
        //        characterSelect = 3;
        //        break;
        //    case 3:
        //        characterSelect = 1;
        //        break;
        //    default:
        //        break;
        //}
        if (characterSelect == 1 && levelManagerScript.upgradeCount > 0)
        {
            characterSelect = 2;
        }
        else if (characterSelect == 2 && levelManagerScript.upgradeCount < 2)
        {
            characterSelect = 1;

        }
        //Be sure to increase the upgrade to 6-8 so you get this form toward mid-game.
        else if (characterSelect == 2 && levelManagerScript.upgradeCount >= 2)
        {
            characterSelect = 3;

        }
        else if (characterSelect == 3)
        {
            characterSelect = 1;
        }
        //-------------------------------

        if (characterSelect == 1)
            {
                tv.SetActive(true);
                isTV = true;
                isPlasma = false;
                plasma.SetActive(false);
                isSmart = false;
                smart.SetActive(false);
            }

            else if (characterSelect == 2)
            {

                tv.SetActive(false);
                plasma.SetActive(true);
                isPlasma = true;
                isTV = false;
                isSmart = false;
                smart.SetActive(false);
            }
            else if (characterSelect == 3)
            {
                isSmart = true;
                smart.SetActive(true);
                tv.SetActive(false);
                plasma.SetActive(false);
                isPlasma = false;
                isTV = false;

            }
    }

    public void TransformToTeev()
    {
        characterSelect = 1;
        tv.SetActive(true);
        isTV = true;
        isPlasma = false;
        plasma.SetActive(false);
        isSmart = false;
        smart.SetActive(false);
    }
}
