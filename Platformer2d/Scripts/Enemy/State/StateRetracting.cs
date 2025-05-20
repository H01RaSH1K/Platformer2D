using System.Collections;
using UnityEngine;

public class StateRetracting : EnemyState
{
    private float _retractingTime = 2f;
    private MonoBehaviour _coroutineRunner;
    private Transform _transform;
    private Walker _walker;
    private PlayerFinder _playerDetectionZone;
    private WaitForSeconds _waitForStop;
    private Coroutine _stoppingCoroutine;

    public StateRetracting(
        IStateChanger stateChanger, MonoBehaviour coroutineRunner, Transform transform, Walker walker,
        PlayerFinder playerDetectionZone
    ) : base(stateChanger)
    {
        _waitForStop = new WaitForSeconds(_retractingTime);
        _coroutineRunner = coroutineRunner;
        _transform = transform;
        _walker = walker;
        _playerDetectionZone = playerDetectionZone;
    }

    public override void Enter()
    {
        _stoppingCoroutine = _coroutineRunner.StartCoroutine(StoppingCoroutine());
    }

    public override void Update()
    {
        if (_playerDetectionZone.CurrentTarget == null)
        {
            StateChanger.ChangeState(EnemyStateType.Patrolling);
            return;
        }

        float retractingDirection = _transform.position.x - _playerDetectionZone.CurrentTarget.transform.position.x;

        _walker.WalkBackwards(retractingDirection);
    }

    public override void Exit()
    {
        _coroutineRunner.StopCoroutine(_stoppingCoroutine);
        _stoppingCoroutine = null;
        _walker.Walk(0);
    }

    private IEnumerator StoppingCoroutine()
    {
        yield return _waitForStop;

        StateChanger.ChangeState(EnemyStateType.Aggressive);
    }
}
