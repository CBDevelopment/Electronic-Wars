using UnityEngine;
using System.Collections;

public class TransformationCloud : MonoBehaviour
{
    private LevelManager levelManagerScript;
    private Evolve evolveScript;

    public Animator transformationCloudAnimator;

    // Use this for initialization
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManager>();
        evolveScript = FindObjectOfType<Evolve>();
        //anim = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Transform") && levelManagerScript.upgradeCount >= 1)
        {
            evolveScript.Transform();
            GetComponent<Animator>().Play("Transforming");
            
        }
    }
}
