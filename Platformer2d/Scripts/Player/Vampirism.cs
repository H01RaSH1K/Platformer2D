using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private Health _health;
    [SerializeField] private float _radius;
    [SerializeField] private float _tickTime;
    [SerializeField] private int _damagePerTick;
    [SerializeField] private int _maxCharge;
    [SerializeField] private int _chargeConsumptionPerTick;
    [SerializeField] private int _chargeRecoveryPerTick;

    private WaitForSeconds _waitForTick;
    private Coroutine _workCoroutine;

    public event Action Enabled;
    public event Action Disabled;
    public event Action ChargeChanged;

    public int Charge {get; private set;}
    public int MaxCharge => _maxCharge;
    public float Radius => _radius;

    private void Awake()
    {
        _waitForTick = new WaitForSeconds(_tickTime);
        Charge = MaxCharge;
    }

    private void OnEnable()
    {
        DisableVampirism();
        ChargeChanged?.Invoke();
        _inputService.VamppirismButtonPressed += EnableVampirism;
    }

    private void OnDisable()
    {
        _inputService.VamppirismButtonPressed -= EnableVampirism;
    }

    private void EnableVampirism()
    {
        if (Charge < _maxCharge)
            return;

        _workCoroutine = StartCoroutine(WorkCoroutine());
        Enabled?.Invoke();
    }

    private void DisableVampirism()
    {
        if (_workCoroutine != null)
        {
            StopCoroutine(_workCoroutine);
            _workCoroutine = null;
        }

        StartCoroutine(CooldownCoroutine());
        Disabled?.Invoke();
    }

    private IEnumerator WorkCoroutine()
    {
        while (Charge != 0)
        {
            yield return _waitForTick;

            SetCharge(Math.Max(0, Charge - _chargeConsumptionPerTick));
            Enemy enemy = GetClosestEnemyInRadius();

            if (enemy == null)
                continue;

            _health.TakeHeal(Math.Min(_damagePerTick, enemy.Health.Count));
            enemy.Health.TakeDamage(_damagePerTick);
        }

        DisableVampirism();
    }

    private IEnumerator CooldownCoroutine()
    {
        while (Charge != _maxCharge)
        {
            yield return _waitForTick;

            SetCharge(Math.Min(_maxCharge, Charge + _chargeRecoveryPerTick));
        }
    }

    private Enemy GetClosestEnemyInRadius()
    {
        Enemy closestEnemy = null;
        float distanceToClosestEnemySquared = float.MaxValue;

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _radius))
        {
            if (collider.TryGetComponent(out Enemy enemy) == false)
                continue;

            float distanceSquared = (enemy.transform.position - transform.position).sqrMagnitude;

            if (distanceSquared < distanceToClosestEnemySquared)
            {
                closestEnemy = enemy;
                distanceToClosestEnemySquared = distanceSquared;
            }
        }

        return closestEnemy;
    }

    private void SetCharge(int charge)
    {
        Charge = charge;
        ChargeChanged?.Invoke();
    }
}
