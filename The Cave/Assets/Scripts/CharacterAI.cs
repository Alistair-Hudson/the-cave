using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 goal;
    Block blockToMine;

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
        if (blockToMine != null)
        {
            if (Vector3.Distance(blockToMine.transform.position, transform.position) <= 
                    blockToMine.GetComponentInChildren<BoxCollider>().size.x + 1)
            {
                goal = transform.position;
                blockToMine.MineBlock();
            }
        }
        navMeshAgent.SetDestination(goal);
    }

    private void ProcessMouseClick()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                blockToMine = hit.transform.GetComponentInParent<Block>();
                goal = hit.point;
                if (blockToMine != null)
                {
                    goal = blockToMine.transform.position;
                }
            }
        }
    }

}
