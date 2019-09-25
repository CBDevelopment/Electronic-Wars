using UnityEngine;
using System.Collections;

public class BGScrollSecondary : MonoBehaviour
{

    public float scrollSpeed;
    public Vector2 startPos;
    public int SwitchValue;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, SwitchValue);
        transform.position = startPos + Vector2.left * newPos;
    }
}