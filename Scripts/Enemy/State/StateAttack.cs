using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : EnemyState
{
    private float _attackingTime = 1f;
    private int _damage = 10;

    private WaitForSeconds _waitForStop;
    private Coroutine _stoppingCoroutine;

    public StateAttack(Enemy enemy) : base(enemy)
    {
        _waitForStop = new WaitForSeconds(_attackingTime);
    }

    public override void Enter()
    {
        _stoppingCoroutine = _enemy.StartCoroutine(StoppingCoroutine());

        Vector2 playerDirection = _enemy.JawsReach.CurrentTarget.transform.position - _enemy.transform.position;
        _enemy.Walker.enabled = false;
        _enemy.Dasher.Dash(playerDirection);
    }

    public override void BehaveOnUpdate()
    {
        if (CanHit(out Player player))
        {
            player.TakeDamage(_damage);
            _enemy.SetState<StateRetracting>();
        }
    }

    public override void Exit()
    {
        _enemy.Walker.enabled = true;
        _enemy.StopCoroutine(_stoppingCoroutine);
        _stoppingCoroutine = null;
    }

    private IEnumerator StoppingCoroutine()
    {
        yield return _waitForStop;

        _enemy.SetState<StateRetracting>();
    }

    public bool CanHit(out Player player)
    {
        player = null;
        RaycastHit2D hit = _enemy.WallChecker.CheckObstacle();

        if (!hit)
            return false;

        return hit.collider.gameObject.TryGetComponent(out player);
    }
}
