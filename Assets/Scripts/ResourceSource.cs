using System.Collections;
using Interfaces;
using UnityEngine;

public abstract class ResourceSource : MonoBehaviour, IInteractable
{
    protected ResourceManager ResourceManager;

    private Coroutine _cutCoroutine;
    
    private void Awake()
    {
        ResourceManager = GameObject.FindWithTag("ResourceManager").GetComponent<ResourceManager>();
    }
    
    public void StartInteraction()
    {
        _cutCoroutine = StartCoroutine(InteractionTickCoroutine());
    }
    
    public void StopInteraction()
    {
        StopCoroutine(_cutCoroutine);
    }

    protected abstract IEnumerator InteractionTickCoroutine();
}