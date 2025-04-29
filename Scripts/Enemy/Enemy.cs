using System;
using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Dasher))]
public class Enemy : Creature
{
    [SerializeField] private ObstacleChecker _wallChecker;
    [SerializeField] PlayerFinder _playerDetectionZone;
    [SerializeField] PlayerFinder _jawsReach;

    private EnemyStateMachine _stateMachine;

    public ObstacleChecker WallChecker => _wallChecker;
    public PlayerFinder PlayerDetectionZone => _playerDetectionZone;
    public PlayerFinder JawsReach => _jawsReach;
    public Walker Walker { get; private set; }
    public Dasher Dasher { get; private set; }

    private void Awake()
    {
        Walker = GetComponent<Walker>();
        Dasher = GetComponent<Dasher>();

        _stateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.CurrentState.BehaveOnUpdate();
    }

    public void SetState<T>() where T : EnemyState
    {
        _stateMachine.SetState<T>();
    }
}
