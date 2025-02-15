using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private static readonly Quaternion s_flip = Quaternion.Euler(0, 180, 0);
    private bool _isFacedRight;

    public void UpdateFacingDirection(float direction)
    {
        if (direction < 0 && _isFacedRight == false || direction > 0 && _isFacedRight)
            FlipFacingDirection();
    }

    private void FlipFacingDirection()
    {
        _isFacedRight = !_isFacedRight;
        transform.rotation *= s_flip;
    }
}
