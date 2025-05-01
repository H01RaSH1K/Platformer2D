using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CreatureAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartWalk()
    {
        _animator.SetBool(AnimatorParams.IsRunning, true);
    }

    public void StopWalk()
    {
        _animator.SetBool(AnimatorParams.IsRunning, false);
    }
}
