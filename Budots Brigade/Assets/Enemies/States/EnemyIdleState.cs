using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    public EnemyIdleState(EnemyEntity enemy, EnemyStateMachine enemyStateMachine, SteeringBehaviors enemySteeringBehaviors): base(enemy, enemyStateMachine, enemySteeringBehaviors)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enter idle state");
        _targetPos = GetRandomPointInCircle();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        _direction = (_targetPos - enemy.transform.position).normalized;

        //enemy.MoveEnemy(_direction * enemy.RandomMovementRange);
        enemySteeringBehaviors.SteerSlowly(enemySteeringBehaviors.Seek(_targetPos));

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 1f)
        {
            _targetPos = GetRandomPointInCircle();
        }

        if (enemy.IsAggroed)
        {
            Debug.Log("Idle to Attack");
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private Vector3 GetRandomPointInCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
    }
}
