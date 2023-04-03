using System;
using Interfaces;
using UnityEngine;

public class Foundry : MonoBehaviour, IInteractable
{
    private ResourceManager _resourceManager;
    
    private void Awake()
    {
        _resourceManager = GameObject.FindWithTag("ResourceManager").GetComponent<ResourceManager>();
    }

    public void StartInteraction()
    {
        Debug.Log("Foundry interact");
    }
    
    public void StopInteraction()
    {
        Debug.Log("Foundry stop interact");
    }
}
