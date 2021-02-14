using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] Building[] buildingPrefabs;
    [SerializeField] CharacterAI player;
    ResourceHandler resourceHandler;

    int selectedBuilding = 0;

    private void Start()
    {
        resourceHandler = FindObjectOfType<ResourceHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaceBuilding();

    }

    private void PlaceBuilding()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (HaveEnoughResources())
                {
                    for (ResourceType type = 0; type < ResourceType.NUM_RESOURCE_TYPES; ++type)
                    {
                        resourceHandler.AlterResourceAmount(type, -buildingPrefabs[selectedBuilding].GetResourceCost(type));
                    }
                    Building newBuilding = Instantiate(buildingPrefabs[selectedBuilding], hit.point, Quaternion.identity);
                    newBuilding.transform.parent = transform;
                    player.BuildBuilding(newBuilding);
                }
            }
        }
    }

    public void SetSelectedBuilding(int buildingIndex)
    {
        selectedBuilding = buildingIndex;
    }

    private bool HaveEnoughResources()
    {
        for(ResourceType type = 0; type < ResourceType.NUM_RESOURCE_TYPES; ++type)
        {
            if (resourceHandler.GetResourceAmount(type) <
                buildingPrefabs[selectedBuilding].GetResourceCost(type))
            {
                return false;
            }
        }
        return true;
    }
}
