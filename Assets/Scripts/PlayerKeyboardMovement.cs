using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(PlayerAnimator))]
public class PlayerKeyboardMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    
    private PlayerAnimator _animator;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<PlayerAnimator>();
        
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        Vector3 input = _playerInput.Player.Movement.ReadValue<Vector2>();

        if (input.x != 0 || input.y != 0)
        {
            _animator.IsRunning = true;
            
            Vector3 movementDirection = new Vector3(input.x, 0.0f, input.y);
            Vector3 movementPosition = transform.position + movementDirection;
            _navMeshAgent.SetDestination(movementPosition);
            
            return;
        }
       
        _animator.IsRunning = false;
        
        _navMeshAgent.SetDestination(transform.position);
    }
}
