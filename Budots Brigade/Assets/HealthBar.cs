using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float n;
    private float max;

    [SerializeField] public RectTransform over;
    float initWidth;

    void Start()
    {
        max = 100;
        initWidth = over.rect.width;
    }

    void Update()
    {
        Debug.Log(n);
        float newWidth = n/max * initWidth;
        over.sizeDelta = new Vector2 (newWidth, 69.0816f);
    }
}
