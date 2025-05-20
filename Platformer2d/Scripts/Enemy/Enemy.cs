using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Dasher))]
public class Enemy : Creature
{
    [SerializeField] private ObstacleScanner _frontObstacleScanner;
    [SerializeField] private PlayerFinder _playerDetectionZone;
    [SerializeField] private PlayerFinder _jawsReach;
    private Walker _walker;
    private Dasher _dasher;
    private EnemyStateMachine _enemyStateMachine;

    protected override void Awake()
    {
        base.Awake();

        _walker = GetComponent<Walker>();
        _dasher = GetComponent<Dasher>();

        _enemyStateMachine = new EnemyStateMachine(this, transform, _walker, _dasher, _frontObstacleScanner, _jawsReach, _playerDetectionZone);
    }

    private void Update()
    {
        _enemyStateMachine.CurrentState.Update();
    }
}
