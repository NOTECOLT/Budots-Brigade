using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Camera cam;
    [SerializeField] public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = Vector3.zero;
    
    [SerializeField] private float closeRadius = 30f;

    // Start is called before the first frame update
    void Start()
    {
        cam.enabled = true;
        cam.orthographicSize = 12.0f;
        offset = transform.position - target.transform.position;

    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.transform.position + offset;
        Vector2 newOffset = transform.position - target.transform.position;
        if (newOffset.magnitude > closeRadius){
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime*3);
        } else {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime/2);
        }
        
    }

}
