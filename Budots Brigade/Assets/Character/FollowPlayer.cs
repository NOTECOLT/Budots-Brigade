using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = targetPosition; //Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
