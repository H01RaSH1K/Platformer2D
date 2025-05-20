using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private readonly Quaternion _flip = Quaternion.Euler(0, 180, 0);
    private bool _isFacedRight;

    public void UpdateFacingDirection(float direction)
    {
        if (direction < 0 && _isFacedRight == false || direction > 0 && _isFacedRight)
            FlipFacingDirection();
    }

    private void FlipFacingDirection()
    {
        _isFacedRight = !_isFacedRight;
        transform.rotation *= _flip;
    }
}
