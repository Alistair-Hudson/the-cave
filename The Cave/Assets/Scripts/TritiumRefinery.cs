using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TritiumRefinery : Building
{
    [SerializeField] float tritiumPerSecond = 1f;
    [SerializeField] float waterRequiredPerSecond = 5f;

    ResourceHandler resources = null;
    TritiumHandler tritium = null;

    // Start is called before the first frame update
    void Start()
    {
        resources = FindObjectOfType<ResourceHandler>();
        tritium = FindObjectOfType<TritiumHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasEnoughIce())
        {
            resources.AlterResourceAmount(ResourceType.HEAVY_WATER, -waterRequiredPerSecond * Time.deltaTime);
            tritium.AlterTritiumAmount(tritiumPerSecond * Time.deltaTime);
        }
    }

    private bool HasEnoughIce()
    {
        return waterRequiredPerSecond * Time.deltaTime < resources.GetResourceAmount(ResourceType.HEAVY_WATER);
    }
}
