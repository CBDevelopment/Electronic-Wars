using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorldMapButton : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Do something.
    }

    // When selected.
    public void OnSelect(BaseEventData eventData)
    {
        // Do something.
        //anim.SetBool("Selected", true);
        //anim.Play("CityNetworkExpand");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // Do something.
        //anim.SetBool("Selected", false);
    }
}
