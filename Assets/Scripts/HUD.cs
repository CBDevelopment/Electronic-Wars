using UnityEngine;
using System.Collections;
//enables using the UI in the script
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HealthSprites;
    public Image HealthUI;

    private PlayerController tvPlayer;
    private PlasmaPlayer plasmaPlayer;

    

    private void Start()
    {
        
        tvPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        plasmaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlasmaPlayer>();

    }

    private void Update()
    {
        HealthUI.sprite = HealthSprites[tvPlayer.currentHealth];
        HealthUI.sprite = HealthSprites[plasmaPlayer.currentHealth];

    }
}
