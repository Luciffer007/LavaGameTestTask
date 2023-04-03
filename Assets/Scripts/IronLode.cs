using System.Collections;
using UnityEngine;

public class IronLode : ResourceSource
{
    protected override IEnumerator InteractionTickCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            ResourceManager.Add(ResourceType.IronOre, 10);
        }
    }
}
