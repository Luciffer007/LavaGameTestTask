using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    public bool IsRunning
    {
        set => _animator.SetBool(Running, value);
    }
    
    private static readonly int Running = Animator.StringToHash("IsRunning");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
