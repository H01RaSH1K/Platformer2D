using UnityEngine;

public class ObstacleScanner : MonoBehaviour
{
    [SerializeField] private float _scanDistance = 0.1f;
    [SerializeField] private Vector2 _scanDirection;
    [SerializeField] private LayerMask _layerMask;
    private int _lastFrameCount;
    private RaycastHit2D _lastHit;

    private Vector2 AbsoluteDirection => transform.TransformDirection(_scanDirection);

    public RaycastHit2D GetObstacle()
    {
        if (_lastFrameCount == Time.frameCount)
            return _lastHit;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, AbsoluteDirection, _scanDistance, _layerMask);
        Debug.DrawRay(transform.position, AbsoluteDirection * _scanDistance, hit.collider ? Color.red : Color.green);
        _lastFrameCount = Time.frameCount;
        _lastHit = hit;
        return hit;
    }
}
