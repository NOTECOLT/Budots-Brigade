using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform t;
	
	Vector2 movement;

    // Animation States
    [SerializeField] public Animator anim;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_DOWN = "PlayerWalkDown";
    const string PLAYER_UP = "PlayerWalkUp";

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
        //normalize the movement somehow??
        movement = movement.normalized;
    }
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        if (movement == Vector2.zero) ChangeAnimationState(PLAYER_IDLE);
        if (movement.y > 0) ChangeAnimationState(PLAYER_UP);
        if (movement.y < 0) ChangeAnimationState(PLAYER_DOWN);
        // Will adjust this to better animations.
        if (movement.x > 0) t.localScale = new Vector3(-1,1,1);
        if (movement.x < 0) t.localScale = new Vector3(1,1,1);
	}

    void ChangeAnimationState(string newState)
    {
        if (newState == currentState) return;
        anim.Play(newState);
        currentState = newState;
    }
}
