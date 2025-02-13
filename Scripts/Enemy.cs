using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ObstacleChecker _wallChecker;

    private float _moveDirection = 1;
    private Mover _mover;

    private static readonly float s_directionFlip = -1;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        UpdateDirections();
    }

    private void Update()
    {
        if (_wallChecker.CheckObstacle())
            FlipMoveDirection();
    }

    private void FlipMoveDirection()
    {
        _moveDirection *= s_directionFlip;
        UpdateDirections();
    }

    private void UpdateDirections()
    {
        _wallChecker.SetDirection(new Vector2(_moveDirection, 0));
        _mover.SetHorizontalDirection(_moveDirection);
    }
}
