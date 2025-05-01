using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action<float> HorizontalAxisChanged;
    public event Action JumpButtonPressed;

    private float _lastHorizontalAxis;

    private void Update()
    {
        HandlerHorizontalAxisInput();
        HandleJumpInput();
    }

    private void HandlerHorizontalAxisInput()
    {
        float horizontalAxis = Input.GetAxisRaw(InputAxis.Horizontal);

        if (horizontalAxis != _lastHorizontalAxis)
        {
            _lastHorizontalAxis = horizontalAxis;
            HorizontalAxisChanged?.Invoke(_lastHorizontalAxis);
        }
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown(InputButtons.Jump))
            JumpButtonPressed?.Invoke();
    }
}
