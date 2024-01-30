using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed = 2f;
    public float maxAcceleration = 25f;
    public float fleeDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 Pos(){
        return (Vector2)transform.position;
    }

    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }
}
