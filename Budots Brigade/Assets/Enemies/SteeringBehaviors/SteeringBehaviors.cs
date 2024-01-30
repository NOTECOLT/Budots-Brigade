using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    MovingEntity movingEntity;
    Rigidbody2D rb;
    float maxSpeed;
    float maxAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingEntity = GetComponent<MovingEntity>();
        maxSpeed = movingEntity.maxSpeed;
        maxAcceleration = movingEntity.maxAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Steer(Vector2 linearAcceleration)
    {
        rb.velocity += linearAcceleration * Time.deltaTime;

        if ( rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public Vector2 Seek(Vector2 targetPos)
    {
        Vector2 targetDirection = (targetPos - movingEntity.Pos()).normalized;
        return targetDirection * maxAcceleration;
    }

    public Vector2 Flee(Vector2 targetPos)
    {
        // flee when target is within panic distance
        Vector2 targetRelativePosition = (movingEntity.Pos() - targetPos);
        Debug.Log("Fleeing distance: " + targetRelativePosition.magnitude);
        if (targetRelativePosition.magnitude < movingEntity.fleeDistance)
        {
            return targetRelativePosition.normalized * maxAcceleration;
        }
        else return Vector2.zero;
    }
}
