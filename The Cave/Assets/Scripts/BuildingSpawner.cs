using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] Building[] buildingPrefabs;
    [SerializeField] CharacterAI player;

    int selectedBuilding = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Building newBuilding = Instantiate(buildingPrefabs[selectedBuilding], hit.point, Quaternion.identity);
                newBuilding.transform.parent = transform;
                player.BuildBuilding(newBuilding);
            }
        }
        
    }
}
