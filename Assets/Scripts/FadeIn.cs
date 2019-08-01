using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeTime;
    public Image blackScreenImage;

	// Use this for initialization
	void Start () {

        blackScreenImage.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        blackScreenImage.CrossFadeAlpha(0f, fadeTime, false);

        if(blackScreenImage.color.a == 0)
        {
            gameObject.SetActive(false);
        }
	}
}
