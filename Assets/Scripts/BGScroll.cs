using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed;
    private MeshRenderer meshRenderer;

    private float scrollX;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        scrollX = Time.time * scrollSpeed;

        Vector2 offset = new Vector2(scrollX , 0f);

        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
