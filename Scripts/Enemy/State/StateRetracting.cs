using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRetracting : EnemyState
{
    private float _retractingTime = 5f;

    private WaitForSeconds _waitForStop;
    private Coroutine _stoppingCoroutine;

    public StateRetracting(Enemy enemy) : base(enemy)
    {
        _waitForStop = new WaitForSeconds(_retractingTime);
    }

    public override void Enter()
    {
        _stoppingCoroutine = _enemy.StartCoroutine(StoppingCoroutine());
    }

    public override void BehaveOnUpdate()
    {
        if (_enemy.PlayerDetectionZone.CurrentTarget == null)
        {
            _enemy.SetState<StatePatrolling>();
            return;
        }

        float retractingDirection = _enemy.transform.position.x - _enemy.PlayerDetectionZone.CurrentTarget.transform.position.x;

        _enemy.Walker.WalkBackwards(retractingDirection);
    }

    public override void Exit()
    {
        _enemy.StopCoroutine(_stoppingCoroutine);
        _stoppingCoroutine = null;
        _enemy.Walker.Walk(0);
    }

    private IEnumerator StoppingCoroutine()
    {
        yield return _waitForStop;

        _enemy.SetState<StateAggressive>();
    }
}
