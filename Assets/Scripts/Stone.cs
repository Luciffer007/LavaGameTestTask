using System.Collections;
using UnityEngine;

public class Stone : ResourceSource
{
    protected override IEnumerator InteractionTickCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            ResourceManager.Add(ResourceType.Stone, 10);
        }
    }
}
