using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyEntity enemy, EnemyStateMachine enemyStateMachine, SteeringBehaviors enemySteeringBehaviors): base(enemy, enemyStateMachine, enemySteeringBehaviors)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.FrameUpdate();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
