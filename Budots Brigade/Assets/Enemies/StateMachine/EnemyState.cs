using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyState
{
    protected EnemyEntity enemy;
    protected EnemyStateMachine enemyStateMachine;
    protected SteeringBehaviors enemySteeringBehaviors;

    public EnemyState(EnemyEntity enemy, EnemyStateMachine enemyStateMachine, SteeringBehaviors enemySteeringBehaviors)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        this.enemySteeringBehaviors = enemySteeringBehaviors;
    }

    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void FrameUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void AnimationTriggerEvent() {
        
    }
}
