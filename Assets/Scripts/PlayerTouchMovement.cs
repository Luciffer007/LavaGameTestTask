using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(NavMeshAgent), typeof(PlayerAnimator))]
public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] 
    private FloatingJoystick joystick;
    
    [SerializeField]
    private Vector2 joystickSize = new Vector2(300.0f, 300.0f);

    private NavMeshAgent _navMeshAgent;

    private PlayerAnimator _animator;

    private Finger _movementFinger;

    private Vector2 _movementDirection;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();

        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleFingerUp;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleFingerUp;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        
        EnhancedTouchSupport.Disable();
    }
    
    private void HandleFingerDown(Finger touchedFinger)
    {
        if (_movementFinger == null /* && touchedFinger.screenPosition.x <= Screen.width / 2.0f */)
        {
            _movementFinger = touchedFinger;
            _movementDirection = Vector2.zero;
            
            joystick.gameObject.SetActive(true);
            joystick.RectTransform.sizeDelta = joystickSize;
            joystick.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
        }
    }

    private Vector2 ClampStartPosition(Vector2 startPosition)
    {
        if (startPosition.x < joystickSize.x / 2.0f)
        {
            startPosition.x = joystickSize.x / 2.0f;
        }

        if (startPosition.y < joystickSize.y / 2.0f)
        {
            startPosition.y = joystickSize.y / 2.0f;
        }
        else if (startPosition.y > Screen.height - joystickSize.y / 2.0f)
        {
            startPosition.y = Screen.height - joystickSize.y / 2.0f;
        }

        return startPosition;
    }

    private void HandleFingerUp(Finger lostFinger)
    {
        if (lostFinger == _movementFinger)
        {
            _movementFinger = null;
            _movementDirection = Vector2.zero;
            
            joystick.Knob.anchoredPosition = Vector2.zero;
            joystick.gameObject.SetActive(false);
        }
    }
    
    private void HandleFingerMove(Finger movedFinger)
    {
        if (movedFinger == _movementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = joystickSize.x / 2.0f;
            ETouch.Touch currentTouch = _movementFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, joystick.RectTransform.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - joystick.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joystick.RectTransform.anchoredPosition;
            }
            
            joystick.Knob.anchoredPosition = knobPosition;
            _movementDirection = knobPosition.normalized;
        }
    }
    
    private void Update()
    {
        if (_movementDirection.x != 0 || _movementDirection.y != 0)
        {
            _animator.IsRunning = true;
            
            Vector3 direction = new Vector3(_movementDirection.x, 0.0f, _movementDirection.y);
            Vector3 movementPosition = transform.position + direction;
            _navMeshAgent.SetDestination(movementPosition);
            
            return;
        }
       
        _animator.IsRunning = false;
        
        _navMeshAgent.SetDestination(transform.position);
    }
}
