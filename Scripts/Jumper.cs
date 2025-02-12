using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private ObstacleChecker _groundChecker;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TryJump()
    {
        bool isGrounded = _groundChecker.CheckObstacle();

        if (isGrounded && Input.GetButtonDown(InputButtons.Jump))
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }
}
