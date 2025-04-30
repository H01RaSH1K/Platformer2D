public class StatePatrolling : EnemyState
{
    private static readonly float s_directionFlip = -1;
    private Walker _walker;
    private PlayerFinder _playerDetectionZone;
    private ObstacleChecker _wallChecker;
    private float _walkingDirection = 1;


    public StatePatrolling(IStateChanger stateChanger, Walker walker, PlayerFinder playerDetectionZone, ObstacleChecker wallChecker) : base(stateChanger)
    {
        _walker = walker;
        _playerDetectionZone = playerDetectionZone;
        _wallChecker = wallChecker;
    }

    public override void Enter()
    {
        _walker.Walk(_walkingDirection);
    }

    public override void BehaveOnUpdate()
    {
        if (_playerDetectionZone.CurrentTarget != null)
        {
            StateChanger.ChangeState(EnemyStateType.Aggressive);
            return;
        }

        if (_wallChecker.CheckObstacle())
            FlipWalkingDirection();
    }

    public override void Exit()
    {
        _walker.Walk(0);
    }

    private void FlipWalkingDirection()
    {
        _walkingDirection *= s_directionFlip;
        _walker.Walk(_walkingDirection);
    }
}
