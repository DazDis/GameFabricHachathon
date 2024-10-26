using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionAnimation : MonoBehaviour
{
    public float startXScale = 0.01f;
    public float startYScale = 0.01f;
    public float endXScale = 2f;
    public float endYScale = 2f;
    public float duration = 2f;

    private float startXScale_temp;
    private float startYScale_temp;

    private float elapsedTime;

    private void Start()
    {
        startXScale_temp = startXScale;
        startYScale_temp = startYScale;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);

        float currentXScale = Mathf.SmoothStep(startXScale, endXScale, t);
        float currentYScale = Mathf.SmoothStep(startYScale, endYScale, t);

        transform.localScale = new Vector3(currentXScale, currentYScale, 1f);

        if (elapsedTime >= duration)
        {
            startXScale = startXScale_temp;
            startYScale = startYScale_temp;
            elapsedTime = 0;
        }
    }
}