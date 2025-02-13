using UnityEngine;

[RequireComponent(typeof(Walker))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ObstacleChecker _wallChecker;

    private float _walkingDirection = 1;
    private Walker _walker;

    private static readonly float s_directionFlip = -1;

    private void Awake()
    {
        _walker = GetComponent<Walker>();
        UpdateDirections();
    }

    private void Update()
    {
        if (_wallChecker.CheckObstacle())
            FlipWalkingDirection();
    }

    private void FlipWalkingDirection()
    {
        _walkingDirection *= s_directionFlip;
        UpdateDirections();
    }

    private void UpdateDirections()
    {
        _wallChecker.SetDirection(new Vector2(_walkingDirection, 0));
        _walker.SetWalkingDirection(_walkingDirection);
    }
}
