using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private ObstacleScanner _bottomObstacleScanner;

    private Rigidbody2D _rigidbody;
    private Coroutine _jumpingCoroutine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_jumpingCoroutine == null)
            _jumpingCoroutine = StartCoroutine(JumpOnFixedUpdate());
    }

    private IEnumerator JumpOnFixedUpdate()
    {
        yield return new WaitForFixedUpdate();

        bool isGrounded = _bottomObstacleScanner.GetObstacle();

        if (isGrounded)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);

        _jumpingCoroutine = null;
    }
}
