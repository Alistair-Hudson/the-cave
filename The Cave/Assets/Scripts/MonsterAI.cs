using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] float fightRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float dps = 50f;
    [SerializeField] int health = 100;


    NavMeshAgent navMeshAgent;
    PlayerAsset[] playerAssets;
    float distanceToTarget = Mathf.Infinity;

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

    private void OnParticleCollision(GameObject other)
    {
        --health;
        if (0 >= health)
        {
            Destroy(gameObject);
        }
    }

    private void EngageTarget(PlayerAsset asset)
    {
        if (Vector3.Distance(transform.position, asset.transform.position) >= 
            (asset.GetComponent<BoxCollider>().size.x + 1))
        {
            MoveToAsset(asset);
            return;
        }
        FaceAsset(asset);
        AttackAsset(asset);
        
    }

    private void MoveToAsset(PlayerAsset asset)
    {
        GetComponent<Animator>().SetTrigger("TriggerMove");
        navMeshAgent.SetDestination(asset.transform.position);
    }

    private void AttackAsset(PlayerAsset asset)
    {

        GetComponent<Animator>().SetTrigger("TriggerAttack");
        HitTarget(asset);

    }

    void HitTarget(PlayerAsset asset)
    {
        asset.TryGetComponent<Building>(out Building building);
        building.TakeDamage(dps * Time.deltaTime);
    }

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
