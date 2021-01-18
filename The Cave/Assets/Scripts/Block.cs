using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] ResourceHandler resourceHandler;
    [SerializeField] int availbleResources = 100;
    [SerializeField] ResourceType resourceType = ResourceType.TITANIUM;

    public Vector3 GetGridPos()
    {
        return new Vector3(Mathf.RoundToInt(transform.position.x / transform.lossyScale.x) * transform.lossyScale.x,
                           Mathf.RoundToInt(transform.position.y / transform.lossyScale.y) * transform.lossyScale.y,
                           Mathf.RoundToInt(transform.position.z / transform.lossyScale.z) * transform.lossyScale.z);
    }

    public void MineBlock()
    {
        --availbleResources;
        resourceHandler.AlterResourceAmount(resourceType, 1);
        if (0 >= availbleResources)
        {
            Destroy(gameObject);
        }
    }

    public int GetAvailbleResources()
    {
        return availbleResources;
    }
}
