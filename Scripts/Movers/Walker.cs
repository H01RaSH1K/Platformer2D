using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Flipper))]
public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _movementSmoothing = 0.05f;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private Flipper _flipper;

    private bool _isWalkingBackwards;
    private float _walkingDirection;
    private Vector3 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_walkingDirection * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, movement, ref _velocity, _movementSmoothing);
        _animator.SetBool(AnimatorParams.IsRunning, Mathf.Approximately(_walkingDirection, 0) == false);
        _flipper.UpdateFacingDirection(GetFacingDirection());
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
