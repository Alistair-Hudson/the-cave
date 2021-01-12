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
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                goal = hit.point;
                blockToMine = hit.transform.GetComponentInParent<Block>();
            }
        }
        navMeshAgent.SetDestination(goal);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Block collideWith = collision.transform.GetComponentInParent<Block>();
        if (collideWith != null)
        {
            if (collideWith.name == blockToMine.name)
            {
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
