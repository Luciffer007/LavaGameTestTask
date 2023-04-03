using System.Collections;
using UnityEngine;

public class Tree : ResourceSource
{
    protected override IEnumerator InteractionTickCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            ResourceManager.Add(ResourceType.Wood, 10);
        }
    }
}
