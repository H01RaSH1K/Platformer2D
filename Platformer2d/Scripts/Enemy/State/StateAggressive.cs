using UnityEngine;

public class StateAggressive : EnemyState
{
    private float _walkingThreshold = 3f;
    private Transform _transform;
    private Walker _walker;
    private PlayerFinder _playerDetectionZone;
    private PlayerFinder _jawsReach;

    public StateAggressive(
        IStateChanger stateChanger, Transform transform, Walker walker,
        PlayerFinder jawsReach, PlayerFinder playerDetectionZone
    ) : base(stateChanger)
    {
        _transform = transform;
        _walker = walker;
        _jawsReach = jawsReach;
        _playerDetectionZone = playerDetectionZone;
    }

    public override void Enter()
    {
    }

    public override void Update()
    {
        if (CanAttack())
        {
            StateChanger.ChangeState(EnemyStateType.Attack);
            return;
        }

        Player player = _playerDetectionZone.CurrentTarget;

        if (player == null)
        {
            StateChanger.ChangeState(EnemyStateType.Patrolling);
            return;
        }

        ChasePlayer(player);
    }

    public override void Exit()
    {
        _walker.Walk(0);
    }

    private bool CanAttack()
    {
        return _jawsReach.CurrentTarget != null;
    }

    private void ChasePlayer(Player player)
    {
        float playerDirection = player.transform.position.x - _transform.position.x;

        if (Mathf.Abs(playerDirection) > _walkingThreshold)
            _walker.Walk(playerDirection);
        else
            _walker.Walk(0);
    }
}
