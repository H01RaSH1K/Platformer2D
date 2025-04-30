using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private float _checkDistance = 0.1f;
    [SerializeField] private Vector2 _checkDirection;
    [SerializeField] private LayerMask _layerMask;
    private int _lastFrameCount;
    private RaycastHit2D _lastHit;

    private Vector2 AbsoluteDirection => transform.TransformDirection(_checkDirection);

    public RaycastHit2D CheckObstacle()
    {
        if (_lastFrameCount == Time.frameCount)
            return _lastHit;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, AbsoluteDirection, _checkDistance, _layerMask);
        Debug.DrawRay(transform.position, AbsoluteDirection * _checkDistance, hit.collider ? Color.red : Color.green);
        _lastFrameCount = Time.frameCount;
        _lastHit = hit;
        return hit;
    }
}
