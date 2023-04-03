using Interfaces;
using UnityEngine;

public class StonemasonWorkshop : MonoBehaviour, IInteractable
{
    private ResourceManager _resourceManager;
    
    private void Awake()
    {
        _resourceManager = GameObject.FindWithTag("ResourceManager").GetComponent<ResourceManager>();
    }
    
    public void StartInteraction()
    {
        Debug.Log("Stonemason workshop interact");
    }
    
    public void StopInteraction()
    {
        Debug.Log("Stonemason workshop stop interact");
    }
}
