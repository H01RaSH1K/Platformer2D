using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _movementSmoothing = 0.05f;
    [SerializeField] private CreatureAnimator _animator;
    [SerializeField] private Flipper _flipper;

    private Rigidbody2D _rigidbody;

    private bool _isWalkingBackwards;
    private float _walkingDirection;
    private Vector3 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_walkingDirection * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, movement, ref _velocity, _movementSmoothing);
        _flipper.UpdateFacingDirection(GetFacingDirection());

        if (Mathf.Approximately(_walkingDirection, 0))
            _animator.StopWalk();
        else
            _animator.StartWalk();
    }

    public void Walk(float direction)
    {
        _walkingDirection = NormalizeDirection(direction);
        _isWalkingBackwards = false;
    }

    public void WalkBackwards(float direction)
    {
        _walkingDirection = NormalizeDirection(direction);
        _isWalkingBackwards = true;
    }

    private float GetFacingDirection()
    {
        if (_isWalkingBackwards)
            return _walkingDirection * -1; 

        return _walkingDirection;
    }

    private float NormalizeDirection(float direction)
    {
        if (direction == 0f)
            return 0f;

        return direction / Mathf.Abs(direction);
    }
}
