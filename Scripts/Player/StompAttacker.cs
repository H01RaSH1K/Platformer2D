using UnityEngine;

[RequireComponent(typeof(Jumper))]
public class StompAttacker : MonoBehaviour
{
    [SerializeField] private ObstacleScanner _bottomObstacleScanner;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    private Jumper _jumper;
    private float _lastAttackTime;

    private void Awake()
    {
        _jumper = GetComponent<Jumper>();
    }

    private void FixedUpdate()
    {
        if (Time.time - _lastAttackTime < _attackDelay)
            return;

        RaycastHit2D hit = _bottomObstacleScanner.GetObstacle();

        if (hit == false)
            return;

        if (hit.collider.TryGetComponent(out Enemy enemy))
        {
            _jumper.Jump();
            enemy.Health.TakeDamage(_damage);
            _lastAttackTime = Time.time;
        }
    }
}
