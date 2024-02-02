using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float n;
    public float max;

    [SerializeField] public RectTransform over;
    float initWidth;

    void Start()
    {
        
    }
}
