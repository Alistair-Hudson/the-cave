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
                navMeshAgent.ResetPath();
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
                    blockToMine.transform.lossyScale.x + 1)
            {
                navMeshAgent.ResetPath();
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
                if(hit.transform.TryGetComponent<Block>(out blockToMine))
                {
                    goal = blockToMine.transform.position;
                    return;
                }
                if(hit.transform.TryGetComponent<Building>(out buildToRepair))
                {
                    goal = buildToRepair.transform.position;
                    return;
                }
                goal = hit.point;
                
            }
        }
    }

}
