using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Callbacks;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    MovingEntity movingEntity;
    EnemyClass enemyClass;
    Rigidbody2D rb;
    float maxSpeed;
    float maxAcceleration;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingEntity = GetComponent<MovingEntity>();
        enemyClass = GetComponent<EnemyClass>();
        maxSpeed = enemyClass.Speed;
        maxAcceleration = enemyClass.Acceleration;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0) {
            anim.SetInteger("MovementDir", 2);
        } else if (rb.velocity.x < 0) {
            anim.SetInteger("MovementDir", 1);
        } else {
            if (rb.velocity.y != 0) {
                anim.SetInteger("MovementDir", 2);  
            } else {
                anim.SetInteger("MovementDir", 0);
            }
        }
    }

    public void Steer(Vector2 linearAcceleration)
    {
        rb.velocity += linearAcceleration * Time.deltaTime;

        if ( rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void SteerSlowly(Vector2 linearAcceleration)
    {
        rb.velocity += linearAcceleration * Time.deltaTime * 0.2f;

        if ( rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    // STEERING BEHAVIORS
    public Vector2 Seek(Vector2 targetPos)
    {
        Vector2 toTarget = targetPos - movingEntity.Pos();          // position of target relative to movingEntity
        if (toTarget.magnitude > movingEntity.seekMinDistance)
        {
            return toTarget.normalized * maxAcceleration;
        }
        return Vector2.zero;
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
