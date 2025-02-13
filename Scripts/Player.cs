using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
public class Player : MonoBehaviour
{
    private Walker _walker;
    private Jumper _jumper;

    private void Start()
    {
        _walker = GetComponent<Walker>();
        _jumper = GetComponent<Jumper>();
    }

    private void Update()
    {
        float walkingDirection = Input.GetAxisRaw(InputAxis.Horizontal);
        _walker.SetWalkingDirection(walkingDirection);

        if (Input.GetButtonDown(InputButtons.Jump))
            _jumper.Jump();
    }
}
