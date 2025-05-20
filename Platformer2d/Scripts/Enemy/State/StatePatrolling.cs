public class StatePatrolling : EnemyState
{
    private static readonly float s_directionFlip = -1;
    private Walker _walker;
    private PlayerFinder _playerDetectionZone;
    private ObstacleScanner _frontObstacleScanner;
    private float _walkingDirection = 1;


    public StatePatrolling(IStateChanger stateChanger, Walker walker, PlayerFinder playerDetectionZone, ObstacleScanner frontObstacleScanner) : base(stateChanger)
    {
        _walker = walker;
        _playerDetectionZone = playerDetectionZone;
        _frontObstacleScanner = frontObstacleScanner;
    }

    public override void Enter()
    {
        _walker.Walk(_walkingDirection);
    }

    public override void Update()
    {
        if (_playerDetectionZone.CurrentTarget != null)
        {
            StateChanger.ChangeState(EnemyStateType.Aggressive);
            return;
        }

        if (_frontObstacleScanner.GetObstacle())
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
