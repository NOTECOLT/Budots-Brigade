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
    private float delayDash = 1f;
    private bool isDashing = false;

    // Animation States
    [SerializeField] public Animator anim;
    string currentState;
    private bool facingLeft = true;
    private bool facingUp = true;
    private bool prioUp = false;
    private bool isMoving = false;

    [SerializeField] private PlayerStats stats;

    void Start()
    {
        //Initialize stats from stats.
        updateStats();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
        
        movement = movement.normalized;
        prioUp = movement.x == 0;
        isMoving = Mathf.Abs(movement.x) + Mathf.Abs(movement.y) > 0;
    }
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        if (movement.x < 0) facingLeft = true;
        if (movement.x > 0) facingLeft = false; 
        if (movement.y < 0) facingUp = false;
        if (movement.y > 0) facingUp = true; 

        //Debug.Log(prioUp);
        // Debug.Log(isMoving);
        //Debug.Log(facingLeft);
        if (anim){
            if(isDashing)
            {
                if (!prioUp){
                    if (facingLeft) ChangeAnimationState("PLD");
                    else if (!facingLeft) ChangeAnimationState("PRD");
                } else{
                    if (facingUp) ChangeAnimationState("PUD");
                    else if (!facingUp) ChangeAnimationState("PDD");
                }
            }
            else if (isMoving){
                if (!prioUp){
                    if (facingLeft) ChangeAnimationState("PLW");
                    else if (!facingLeft) ChangeAnimationState("PRW");
                } else{
                    if (facingUp) ChangeAnimationState("PUW");
                    else if (!facingUp) ChangeAnimationState("PDW");
                }
            }
            else 
            {
                if (!prioUp){
                    if (facingLeft) ChangeAnimationState("PLI");
                    else if (!facingLeft) ChangeAnimationState("PRI");
                } else{
                    if (facingUp) ChangeAnimationState("PUI");
                    else if (!facingUp) ChangeAnimationState("PDI");
                }
            }
        
        if (Input.GetMouseButtonDown(1) && canDash)
        {
            DashMove();
        }
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
        isDashing = true;
        moveSpeed *= stats.mod_dashMult;
        
        Invoke("DashEnd", delayDash);
    }
    void DashEnd()
    {
        canDash = true;
        isDashing = false;
        moveSpeed = stats.mod_walkSpeed;
    }

    public void updateStats()
    {
        moveSpeed = stats.mod_walkSpeed;
    }

}
