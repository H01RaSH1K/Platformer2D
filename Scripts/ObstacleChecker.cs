using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private float _checkDistance = 0.1f;
    [SerializeField] private Vector2 _checkDirection;
    [SerializeField] private LayerMask _layerMask;

    public bool CheckObstacle()
    {
        return Physics2D.Raycast(transform.position, _checkDirection, _checkDistance, _layerMask);
    }

    public void SetDirection(Vector2 newDirection)
    {
        _checkDirection = newDirection;
    }
}
