using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    // Basics
	[SerializeField] private float moveSpeed = 12f;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform t;
	
	Vector2 movement;

    // Extra Movement
    private bool canDash = true;
    private float regainDash = 1f;
    private float delayDash = 0.3f;
    private bool isDashing = false;

    // Animation States
    [SerializeField] public Animator anim;
    string currentState;
    //private bool isStart = false;
    private bool facingLeft = true;
    private bool facingUp = true;
    private bool prioUp = false;
    private bool isMoving = false;
    private bool isDead = true;
    [SerializeField] private PlayerStats stats;

    // Sounds
    [SerializeField] private AudioClip[] footstepSFX;
    private AudioSource audioSrc;
    private System.Random _r;

    void Start()
    {
        //Initialize stats from stats.
        updateStats();
        audioSrc = GetComponent<AudioSource>();
        _r = new System.Random();
        ChangeAnimationState("Player_Stand");
        Invoke("Activate", 1.5f);
    }

    void Update()
    {
        if (isDead) return;
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
        
        movement = movement.normalized;
        prioUp = movement.x == 0;
        isMoving = Mathf.Abs(movement.x) + Mathf.Abs(movement.y) > 0;
        if (isMoving) {
            if (!audioSrc.isPlaying) {
                audioSrc.clip = footstepSFX[_r.Next(0, footstepSFX.Length)];
                audioSrc.Play();
            }
        }
    }
	
	void LateUpdate()
	{
        if (isDead) return;
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

    public void ChangeAnimationState(string newState)
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
        Invoke("DashGain", regainDash);
    }
    void DashEnd()
    {
        isDashing = false;
        moveSpeed = stats.mod_walkSpeed;
    }
    void DashGain()
    {
        canDash = true;
    }

    public void Activate()
    {
        isDead = false;
    }

    public void Die()
    {
        rb.velocity = Vector2.zero;
        isDead = true;
        ChangeAnimationState("Player_Death");
    }

    public void updateStats()
    {
        moveSpeed = stats.mod_walkSpeed;
    }

    // CALLED UPON BY PLAYER DEATH ANIMATION
    private void DeathScreen()
    {
        SceneManager.LoadScene(4);
    }

}
