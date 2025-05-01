using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : IStateChanger
{
    private Dictionary<EnemyStateType, EnemyState> _states;
    
    public EnemyState CurrentState { get; private set; }

    public EnemyStateMachine(
        MonoBehaviour coroutineRunner, Transform transform, Walker walker, Dasher dasher, 
        ObstacleScanner frontObstacleScanner, PlayerFinder jawsReach, PlayerFinder playerDetectionZone
    )
    {
        _states = new Dictionary<EnemyStateType, EnemyState>();

        _states[EnemyStateType.Patrolling] = new StatePatrolling(this, walker, playerDetectionZone, frontObstacleScanner);
        _states[EnemyStateType.Aggressive] = new StateAggressive(this, transform, walker, jawsReach, playerDetectionZone);
        _states[EnemyStateType.Attack] = new StateAttack(this, coroutineRunner, transform, walker, dasher, frontObstacleScanner, jawsReach);
        _states[EnemyStateType.Retracting] = new StateRetracting(this, coroutineRunner, transform, walker, playerDetectionZone);

        EnterState(EnemyStateType.Patrolling);
    }

    public void ChangeState(EnemyStateType enemyStateType)
    {
        ExitCurrentState();
        EnterState(enemyStateType);
    }

    private void ExitCurrentState()
    {
        CurrentState.Exit();
        CurrentState = null;
    }

    private void EnterState(EnemyStateType enemyStateType)
    {
        EnemyState state;

        if (_states.TryGetValue(enemyStateType, out state) == false)
            return;

        CurrentState = state;
        CurrentState.Enter();
    }
}
