using Interfaces;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] 
    private Transform interactionPoint;
    
    [SerializeField] 
    private float interactionRadius = 0.5f;

    [SerializeField] 
    private LayerMask interactionMask;

    private IInteractable _interactionObject;

    private void Update()
    {
        Collider[] colliders = new Collider[1];
        Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, colliders, interactionMask);
        if (colliders[0] != null)
        {
            _interactionObject = colliders[0].GetComponent<IInteractable>();
            return;
        }

        _interactionObject = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }

    public void StartInteraction()
    {
        if (_interactionObject == null)
        {
            return;
        }
        
        _interactionObject.StartInteraction();
    }
    
    public void StopInteraction()
    {
        if (_interactionObject == null)
        {
            return;
        }
        
        _interactionObject.StopInteraction();
    }
}
