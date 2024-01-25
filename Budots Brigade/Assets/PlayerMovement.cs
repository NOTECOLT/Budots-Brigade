using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float moveSpeed = 5f;
	
	[SerializeField] private Rigidbody2D rb;
	
	Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
    }
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
	}
}
