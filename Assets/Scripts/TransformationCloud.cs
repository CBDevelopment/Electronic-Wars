using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformationCloud : MonoBehaviour
{
    private LevelManager levelManagerScript;
    private Evolve evolveScript;
    public Animator transformationCloudAnimator;
    public Vector3 pos;
    private PlayerController tvPlayer;
    private LastPosition lastPositionScript;

    public Slider TransformCoolDownBar;

    public bool canTransform;
    public float TimeBetweenTransforms = .4f;

    // Use this for initialization
    void Start()
    {
        canTransform = true;
        levelManagerScript = FindObjectOfType<LevelManager>();
        evolveScript = FindObjectOfType<Evolve>();
        tvPlayer = FindObjectOfType<PlayerController>();
        lastPositionScript = FindObjectOfType<LastPosition>();
        //anim = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TransformCoolDownBar.value = TimeBetweenTransforms;

        if (Input.GetButtonDown("Transform") && levelManagerScript.upgradeCount >= 1 && canTransform)
        {
            Invoke("CloudAnimation", 0f);
            canTransform = false;
            TransformCoolDownBar.gameObject.SetActive(true);
        }

        if (!canTransform)
        {
            //There is now a cooldown time between transforms.
            TimeBetweenTransforms -= Time.deltaTime;

        }

        if (TimeBetweenTransforms <= 0f)
        {
            canTransform = true;
            TimeBetweenTransforms = .4f;
            TransformCoolDownBar.gameObject.SetActive(false);

        }
    }

    public void CloudAnimation()
    {
        evolveScript.Transform();
        GetComponent<Animator>().Play("Transforming");

    }
}
