using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dasher : MonoBehaviour
{
    [SerializeField] private float _forceFactor = 80f;
    [SerializeField] private Flipper _flipper;

    private Rigidbody2D _rigidbody;
    private Coroutine _dashingCoroutine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Dash(Vector2 direction)
    {
        if (_dashingCoroutine == null) 
            _dashingCoroutine = StartCoroutine(DashOnFixedUpdate(direction));
    }

    private IEnumerator DashOnFixedUpdate(Vector2 direction)
    {
        yield return new WaitForFixedUpdate();

        direction = direction.x >= 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction.normalized * _forceFactor;
        _rigidbody.AddForce(force, ForceMode2D.Impulse);
        _flipper.UpdateFacingDirection(force.x);

        _dashingCoroutine = null;
    }
}
