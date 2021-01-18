using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    [SerializeField] Resource[] resources;

    [System.Serializable]
    private class Resource
    {
        public ResourceType resourceType;
        public int resourceAmount;
    }

    public int GetResourceAmount(ResourceType resource)
    {
        //Returns -1 if resource type is not found
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i].resourceType == resource)
            {
                return resources[i].resourceAmount;
            }
        }
        return -1;
    }

    public void AlterResourceAmount(ResourceType resource, int amount)
    {
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i].resourceType == resource)
            {
                resources[i].resourceAmount += amount;
                return;
            }
        }
        throw new System.Exception("Resource does not exist");
    }
}
