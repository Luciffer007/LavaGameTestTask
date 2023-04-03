using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int Wood { get; private set; }
    
    public int Stone { get; private set; }
    
    public int IronOre { get; private set; }
    
    public void Add(ResourceType resourceType, int quantity)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                Wood += quantity;
                Debug.Log("Wood: " + Wood);
                break;
            case ResourceType.Stone:
                Stone += quantity;
                Debug.Log("Stone: " + Stone);
                break;
            case ResourceType.IronOre:
                IronOre += quantity;
                Debug.Log("Iron ore: " + IronOre);
                break;
        }
    }

    public void Remove(ResourceType resourceType, int quantity)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                break;
            case ResourceType.Stone:
                break;
            case ResourceType.IronOre:
                break;
        }
    }
}
