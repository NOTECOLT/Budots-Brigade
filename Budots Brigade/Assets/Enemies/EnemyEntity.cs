using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEntity : MonoBehaviour, IDamageable, IEnemyMoveable {
    [field: SerializeField] public float MaxHealth {get; set; }
    [field: SerializeField] public float CurrentHealth{get; set;}
    public Rigidbody2D rb{get; set;}
    public bool IsFacingRight{get; set;} = true;

    #region State Machine Variables
    public EnemyStateMachine StateMachine{get; set;}
    public EnemyIdleState IdleState{get; set;}
    public EnemyChaseState ChaseState{get; set;}
    public EnemyAttackState AttackState{get; set;}
    public EnemyFleeState FleeState{get; set;}
    #endregion

    public EnemyClass enemyClass;
    //protected int _hp;

    #region Idle Variables
    public float RandomMovementRange = 2f;
    public float RandomMovementSpeed = 0.3f;
    #endregion

    SteeringBehaviors steeringBehaviors;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        // IdleState = new EnemyIdleState(this, StateMachine);
        // ChaseState = new EnemyChaseState(this, StateMachine);
        //AttackState = new EnemyAttackState(this, StateMachine);
    }

    void Start() {
        CurrentHealth = MaxHealth;
        rb  = GetComponent<Rigidbody2D>();

        steeringBehaviors = GetComponent<SteeringBehaviors>();

        IdleState = new EnemyIdleState(this, StateMachine, steeringBehaviors);
        ChaseState = new EnemyChaseState(this, StateMachine, steeringBehaviors);
        FleeState = new EnemyFleeState(this, StateMachine, steeringBehaviors);

        StateMachine.Initialize(FleeState);
    }

    void Update() {
        //enemyClass.DoAI(gameObject);

        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    void FixedUpdate() {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void MoveEnemy(Vector2 velocity)
    {
        rb.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
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
}