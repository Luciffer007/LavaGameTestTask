using Interfaces;
using UnityEngine;

public class SawingTable : MonoBehaviour, IInteractable
{
    [SerializeField] 
    private Transform saw;
    
    private ResourceManager _resourceManager;
    
    private void Awake()
    {
        _resourceManager = GameObject.FindWithTag("ResourceManager").GetComponent<ResourceManager>();
    }
    
    public void StartInteraction()
    {
        Debug.Log("Lumber mill interact");
    }
    
    public void StopInteraction()
    {
        Debug.Log("Lumber mill stop interact");
    }
}
