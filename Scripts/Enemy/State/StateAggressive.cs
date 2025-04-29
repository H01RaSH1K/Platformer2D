using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StateAggressive : EnemyState
{
    private float _walkingThreshold = 1.5f;

    public StateAggressive(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
    }

    public override void BehaveOnUpdate()
    {
        if (CanAttack())
        {
            _enemy.SetState<StateAttack>();
            return;
        }

        Player player = _enemy.PlayerDetectionZone.CurrentTarget;

        if (player == null)
        {
            _enemy.SetState<StatePatrolling>();
            return;
        }

        ChasePlayer(player);
    }

    public override void Exit()
    {
        _enemy.Walker.Walk(0);
    }

    private bool CanAttack()
    {
        return _enemy.JawsReach.CurrentTarget != null;
    }

    private void ChasePlayer(Player player)
    {
        float playerDirection = player.transform.position.x - _enemy.transform.position.x;

        if (Mathf.Abs(playerDirection) > _walkingThreshold)
            _enemy.Walker.Walk(playerDirection);
        else
            _enemy.Walker.Walk(0);
    }
}
