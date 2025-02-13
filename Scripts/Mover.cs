using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _movementSmoothing = 0.05f;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;

    private float _horizontalDirection;
    private Vector3 _velocity;
    private bool _isFacedRight;
    private static readonly Quaternion s_flip = Quaternion.Euler(0, 180, 0);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_horizontalDirection * _moveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, movement, ref _velocity, _movementSmoothing);
        _animator.SetBool(AnimatorParams.IsRunning, Mathf.Approximately(_horizontalDirection, 0) == false);
        UpdateFacingDirection(_horizontalDirection);
    }

    public void SetHorizontalDirection(float direction)
    {
        _horizontalDirection = direction;
    }

    private void UpdateFacingDirection(float horizontalMove)
    {
        if (horizontalMove < 0 && _isFacedRight == false || horizontalMove > 0 && _isFacedRight)
            FlipFacingDirection();
    }

    private void FlipFacingDirection()
    {
        _isFacedRight = !_isFacedRight;
        transform.rotation *= s_flip;
    }
}
