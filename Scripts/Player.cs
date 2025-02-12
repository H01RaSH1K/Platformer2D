using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
public class PlayerController : MonoBehaviour
{
    private Mover _mover;
    private Jumper _jumper;

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxisRaw(InputAxis.Horizontal);
        _mover.MoveHorizontaly(horizontalMove);

        if (Input.GetButtonDown(InputButtons.Jump))
            _jumper.TryJump();
    }
}

public static class AnimatorParams
{
    public static readonly int IsRunning = Animator.StringToHash("IsRunning");
}

public static class InputAxis
{
    public static readonly string Horizontal = "Horizontal";
    public static readonly string Verical = "Vertical";
}

public static class InputButtons
{
    public static readonly string Jump = "Jump";
}
