using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 goal;
    Block blockToMine;
    Building buildToRepair;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        goal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMouseClick();
        MineBlock();
        RepairBuilding();
        navMeshAgent.SetDestination(goal);
    }

    public void BuildBuilding(Building building)
    {
        buildToRepair = building;
        goal = buildToRepair.transform.position;
        blockToMine = null;
    }

    private void RepairBuilding()
    {
        if (buildToRepair != null)
        {

            if (Vector3.Distance(buildToRepair.transform.position, transform.position) <=
                    buildToRepair.GetComponentInChildren<BoxCollider>().size.x + 1)
            {
                goal = transform.position;
                if (buildToRepair.RepairDamage(1))
                {
                    buildToRepair = null;
                }
            }
        }
    }

    private void MineBlock()
    {
        if (blockToMine != null)
        {
            if (Vector3.Distance(blockToMine.transform.position, transform.position) <=
                    blockToMine.GetComponentInChildren<BoxCollider>().size.x + 1)
            {
                goal = transform.position;
                blockToMine.MineBlock();
            }
        }
    }

    private void ProcessMouseClick()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                blockToMine = hit.transform.GetComponentInParent<Block>();
                buildToRepair = hit.transform.GetComponentInParent<Building>();
                goal = hit.point;
                if (blockToMine != null)
                {
                    goal = blockToMine.transform.position;
                }
                if (buildToRepair != null)
                {
                    goal = buildToRepair.transform.position;
                }
            }
        }
    }

}
