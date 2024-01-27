using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Basics
	[SerializeField] private float moveSpeed = 12f;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform t;
	
	Vector2 movement;

    // Extra Movement
    private bool canDash = true;
    private float timerDash = 1f; 
    private float delayDash = 0.3f; 

    // Animation States
    [SerializeField] public Animator anim;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_LU = "PlayerWalkLeftUp";
    const string PLAYER_LD = "PlayerWalkLeftDown";
    const string PLAYER_RU = "PlayerWalkRightUp";
    const string PLAYER_RD = "PlayerWalkRightDown";
    private bool facingLeft = true;
    private bool facingUp = true;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        timerDash += Time.deltaTime;
        if (!canDash && timerDash > delayDash){
            canDash = true;
        }
    }
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        if (movement == Vector2.zero) anim.speed = 0f;
        else anim.speed = 1f;

        if (movement.x < 0) facingLeft = true;
        if (movement.x > 0) facingLeft = false; 
        if (movement.y < 0) facingUp = false;
        if (movement.y > 0) facingUp = true; 

        if (anim){
            if (facingUp){
                if (facingLeft) ChangeAnimationState(PLAYER_LU);
                else ChangeAnimationState(PLAYER_RU);
            } else {
                if (facingLeft) ChangeAnimationState(PLAYER_LD);
                else ChangeAnimationState(PLAYER_RD);
            }
        }


        if (Input.GetKeyDown("space"))
        {
            DashMove();
        }
	}

    void ChangeAnimationState(string newState)
    {
        if (newState == currentState) return;
        anim.Play(newState);
        currentState = newState;
    }

    void DashMove()
    {
        canDash = false;
        moveSpeed = 9;
        Invoke("DashEnd", 0.2f);
    }
    void DashEnd()
    {
        moveSpeed = 3;
    }
}
