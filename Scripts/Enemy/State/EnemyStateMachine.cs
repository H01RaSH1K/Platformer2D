using System;
using System.Collections.Generic;

public class EnemyStateMachine
{
    private Dictionary<Type, EnemyState> _states;
    
    public EnemyState CurrentState { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        _states = new Dictionary<Type, EnemyState>();

        _states[typeof(StateAggressive)] = new StateAggressive(enemy);
        _states[typeof(StatePatrolling)] = new StatePatrolling(enemy);
        _states[typeof(StateRetracting)] = new StateRetracting(enemy);
        _states[typeof(StateAttack)] = new StateAttack(enemy);

        EnterState<StatePatrolling>();
    }

    public void SetState<T>() where T : EnemyState
    {
        ExitCurrentState();
        EnterState<T>();
    }

    private void ExitCurrentState()
    {
        CurrentState.Exit();
        CurrentState = null;
    }

    private void EnterState<T>() where T : EnemyState
    {
        EnemyState state;

        if (_states.TryGetValue(typeof(T), out state) == false)
            return;

        CurrentState = state;
        CurrentState.Enter();
    }
}
