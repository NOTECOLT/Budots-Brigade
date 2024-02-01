using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleeState : EnemyState
{
    public EnemyFleeState(EnemyEntity enemy, EnemyStateMachine enemyStateMachine, SteeringBehaviors enemySteeringBehaviors): base(enemy, enemyStateMachine, enemySteeringBehaviors)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        Vector2 targetPosition = (Vector2) GameObject.FindAnyObjectByType<PlayerMovement>().transform.position;
        enemySteeringBehaviors.Steer(enemySteeringBehaviors.Flee(targetPosition));
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}