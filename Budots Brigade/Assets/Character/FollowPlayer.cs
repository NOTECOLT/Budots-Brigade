using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Camera cam;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = Vector3.zero;
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
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
