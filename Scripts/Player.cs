using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
public class Player : MonoBehaviour
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
        _mover.SetHorizontalDirection(horizontalMove);

        if (Input.GetButtonDown(InputButtons.Jump))
            _jumper.Jump();
    }
}
