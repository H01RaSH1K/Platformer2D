using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action<float> HorizontalAxisChanged;
    public event Action JumpButtonPressed;

    private float _lastHorizontalAxis;

    private void Update()
    {
        UpdateHorizontalAxis();
        CheckJump();
    }

    private void UpdateHorizontalAxis()
    {
        float horizontalAxis = Input.GetAxisRaw(InputAxis.Horizontal);

        if (horizontalAxis != _lastHorizontalAxis)
        {
            _lastHorizontalAxis = horizontalAxis;
            HorizontalAxisChanged?.Invoke(_lastHorizontalAxis);
        }
    }

    private void CheckJump()
    {
        if (Input.GetButtonDown(InputButtons.Jump))
            JumpButtonPressed?.Invoke();
    }
}
