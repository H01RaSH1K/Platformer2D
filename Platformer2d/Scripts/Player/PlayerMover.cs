using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputService _inputService;

    private Walker _walker;
    private Jumper _jumper;

    private void Awake()
    {
        _walker = GetComponent<Walker>();
        _jumper = GetComponent<Jumper>();
    }

    private void OnEnable()
    {
        _inputService.HorizontalAxisChanged += UpdateWalkingDirection;
        _inputService.JumpButtonPressed += Jump;
    }

    private void OnDisable()
    {
        _inputService.HorizontalAxisChanged -= UpdateWalkingDirection;
        _inputService.JumpButtonPressed -= Jump;
    }

    private void UpdateWalkingDirection(float direciton)
    {
        _walker.Walk(direciton);
    }

    private void Jump() 
    { 
        _jumper.Jump(); 
    }
}
