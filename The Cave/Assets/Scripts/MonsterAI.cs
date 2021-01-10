using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] float fightRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    //[SerializeField] float damage = 50f;


    NavMeshAgent navMeshAgent;
    PlayerAsset[] playerAssets;
    float distanceToTarget = Mathf.Infinity;
    //bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAssets = FindObjectsOfType<PlayerAsset>();

        PlayerAsset closestAsset = playerAssets[0];

        foreach (PlayerAsset asset in playerAssets)
        {
            float distanceToAsset = Vector3.Distance(asset.transform.position, transform.position);
            float distanceToClosest = Vector3.Distance(closestAsset.transform.position, transform.position);

            if (distanceToAsset < distanceToClosest)
            {
                closestAsset = asset;
            }
        }
        EngageTarget(closestAsset);
    }

    //public void OnHit()
    //{
    //    isProvoked = true;
    //}

    private void EngageTarget(PlayerAsset asset)
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            MoveToAsset(asset);
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            FaceAsset(asset);
            AttackAsset(asset);
        }
    }

    private void MoveToAsset(PlayerAsset asset)
    {
        navMeshAgent.SetDestination(asset.transform.position);
    }

    private void AttackAsset(PlayerAsset asset)
    {
        GetComponent<Animator>().SetTrigger("TriggerAttack");

    }

    //void HitTarget()
    //{
    //    target.GetComponent<PlayerHealth>().TakeDamage(damage);
    //}

    void FaceAsset(PlayerAsset asset)
    {
        Vector3 direction = (asset.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fightRange);
    }
}
