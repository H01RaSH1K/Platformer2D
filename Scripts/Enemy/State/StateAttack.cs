using System.Collections;
using UnityEngine;

public class StateAttack : EnemyState
{
    private float _attackingTime = 1f;
    private int _damage = 10;
    private MonoBehaviour _coroutineRunner;
    private Transform _transform;
    private Walker _walker;
    private Dasher _dasher;
    private ObstacleScanner _frontObstacleScanner;
    private PlayerFinder _jawsReach;
    private WaitForSeconds _waitForStop;
    private Coroutine _stoppingCoroutine;

    public StateAttack(
        IStateChanger stateChanger, MonoBehaviour coroutineRunner, Transform transform, Walker walker,
        Dasher dasher, ObstacleScanner frontObstacleScanner, PlayerFinder jawsReach
    ) : base(stateChanger)
    {
        _waitForStop = new WaitForSeconds(_attackingTime);
        _coroutineRunner = coroutineRunner;
        _transform = transform;
        _walker = walker;
        _dasher = dasher;
        _frontObstacleScanner = frontObstacleScanner;
        _jawsReach = jawsReach;
    }

    public override void Enter()
    {
        _stoppingCoroutine = _coroutineRunner.StartCoroutine(StoppingCoroutine());

        Vector2 playerDirection = _jawsReach.CurrentTarget.transform.position - _transform.position;
        _walker.enabled = false;
        _dasher.Dash(playerDirection);
    }

    public override void BehaveOnUpdate()
    {
        if (CanHit(out Player player))
        {
            player.Health.TakeDamage(_damage);
            StateChanger.ChangeState(EnemyStateType.Retracting);
        }
    }

    public override void Exit()
    {
        _walker.enabled = true;
        _coroutineRunner.StopCoroutine(_stoppingCoroutine);
        _stoppingCoroutine = null;
    }

    private IEnumerator StoppingCoroutine()
    {
        yield return _waitForStop;

        StateChanger.ChangeState(EnemyStateType.Retracting);
    }

    public bool CanHit(out Player player)
    {
        player = null;
        RaycastHit2D hit = _frontObstacleScanner.GetObstacle();

        if (hit == false)
            return false;

        return hit.collider.gameObject.TryGetComponent(out player);
    }
}
