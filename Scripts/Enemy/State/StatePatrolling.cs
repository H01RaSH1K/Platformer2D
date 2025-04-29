using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrolling : EnemyState
{
    private static readonly float s_directionFlip = -1;
    private float _walkingDirection = 1;

    public StatePatrolling(Enemy enemy) : base(enemy) {}

    public override void Enter()
    {
        _enemy.Walker.Walk(_walkingDirection);
    }

    public override void BehaveOnUpdate()
    {
        if (_enemy.PlayerDetectionZone.CurrentTarget != null)
        {
            _enemy.SetState<StateAggressive>();
            return;
        }

        if (_enemy.WallChecker.CheckObstacle())
            FlipWalkingDirection();
    }

    public override void Exit()
    {
        _enemy.Walker.Walk(0);
    }

    private void FlipWalkingDirection()
    {
        _walkingDirection *= s_directionFlip;
        _enemy.Walker.Walk(_walkingDirection);
    }
}
