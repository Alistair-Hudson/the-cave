using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] ResourceType resourceType = ResourceType.TITANIUM;
    ResourceHandler resourceHandler;
    Text resourceDisplay;

    // Start is called before the first frame update
    void Start()
    {
        resourceHandler = GetComponentInParent<ResourceHandler>();
        resourceDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        resourceDisplay.text = resourceHandler.GetResourceAmount(resourceType).ToString();
    }
}
