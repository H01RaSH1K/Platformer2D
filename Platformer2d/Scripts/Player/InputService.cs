using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private float _lastHorizontalAxis;

    public event Action<float> HorizontalAxisChanged;
    public event Action JumpButtonPressed;
    public event Action VamppirismButtonPressed;

    private void Update()
    {
        HandleHorizontalAxisInput();
        HandleButtonsInput();
    }

    private void HandleHorizontalAxisInput()
    {
        float horizontalAxis = Input.GetAxisRaw(InputAxis.Horizontal);

        if (horizontalAxis != _lastHorizontalAxis)
        {
            _lastHorizontalAxis = horizontalAxis;
            HorizontalAxisChanged?.Invoke(_lastHorizontalAxis);
        }
    }

    private void HandleButtonsInput()
    {
        if (Input.GetButtonDown(InputButtons.Jump))
            JumpButtonPressed?.Invoke();

        if (Input.GetButtonDown(InputButtons.Vampirism))
            VamppirismButtonPressed?.Invoke();
    }
}
