using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEntity : MonoBehaviour, IEnemyMoveable, ITriggerCheckable {
    //[field: SerializeField] public float MaxHealth {get; set; }
    //[field: SerializeField] public float CurrentHealth{get; set;}
    float CurrentHealth;
    float MaxHealth;
    public Rigidbody2D rb{get; set;}
    public bool IsFacingRight{get; set;} = true;

    // ITriggerCheckable
    public bool IsAggroed {get; set;}
    public bool IsWithinAttackRange {get; set;}

    EnemyClass enemyClass;

    // STATE MACHINE
    #region State Machine Variables
    public EnemyStateMachine StateMachine{get; set;}
    public EnemyIdleState IdleState{get; set;}
    public EnemyChaseState ChaseState{get; set;}
    public EnemyAttackState AttackState{get; set;}
    public EnemyFleeState FleeState{get; set;}
    #endregion

    #region Idle Variables
    public float RandomMovementRange = 2f;
    public float RandomMovementSpeed = 0.3f;
    public float AggroRadius = 1f;
    #endregion

    SteeringBehaviors steeringBehaviors;
    Animator animator;
    GameObject playerObj;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        // IdleState = new EnemyIdleState(this, StateMachine);
        // ChaseState = new EnemyChaseState(this, StateMachine);
        //AttackState = new EnemyAttackState(this, StateMachine);
    }

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");

        enemyClass = GetComponent<EnemyClass>();
        MaxHealth = enemyClass.MaxHP;

        CurrentHealth = MaxHealth;
        rb  = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

        steeringBehaviors = GetComponent<SteeringBehaviors>();

        IdleState = new EnemyIdleState(this, StateMachine, steeringBehaviors);
        ChaseState = new EnemyChaseState(this, StateMachine, steeringBehaviors);
        FleeState = new EnemyFleeState(this, StateMachine, steeringBehaviors);

        StateMachine.Initialize(ChaseState);
    }

    void Update() {
        // Debug.Log(gameObject.name + " " + IsWithinAttackRange);
        if (IsWithinAttackRange)
        {
            
            enemyClass.DoAttack(playerObj);
        }
    
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    void FixedUpdate() {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
            
        }
        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    public void Damage(float damage)
    {
        animator.SetTrigger("Entity_Hit_Trigger");
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Destroy(gameObject);
    }

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinAttackRange)
    {
        IsWithinAttackRange = isWithinAttackRange;
    }
}