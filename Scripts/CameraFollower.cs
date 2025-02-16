using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _movementThreshold = new Vector3(1f, 1f);
    [SerializeField] private float _smoothTime = 0.2f;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = _target.position;
        Vector3 cameraPosition = transform.position;

        float deltaX = targetPosition.x - cameraPosition.x;
        float deltaY = targetPosition.y - cameraPosition.y;

        float newX = (Mathf.Abs(deltaX) > _movementThreshold.x) ? targetPosition.x : cameraPosition.x;
        float newY = (Mathf.Abs(deltaY) > _movementThreshold.y) ? targetPosition.y : cameraPosition.y;

        Vector3 newPosition = new Vector3(newX, newY, cameraPosition.z);

        transform.position = Vector3.SmoothDamp(cameraPosition, newPosition, ref _velocity, _smoothTime);
    }
}