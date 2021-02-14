using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Building
{
    [SerializeField] float firingRange = 10f;

    MonsterAI target = null;
    ParticleSystem[] guns;

    private void Start()
    {
        guns = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            SetGunState(false);
            FindClosetEnemy();
        }

        transform.LookAt(target.transform);

        if (Vector3.Distance(transform.position, target.transform.position) <
                firingRange)
        {
            SetGunState(true);
        }

    }

    private void SetGunState(bool state)
    {
        foreach (ParticleSystem gun in guns)
        {
            var emissionModule = gun.emission;
            emissionModule.enabled = state;
        }
    }

    private void FindClosetEnemy()
    {
        MonsterAI[] enemies = FindObjectsOfType<MonsterAI>();
        if (enemies.Length <= 0)
        {
            return;
        }
        MonsterAI closetTarget = enemies[0];
        foreach (MonsterAI enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <
                Vector3.Distance(transform.position, closetTarget.transform.position))
            {
                closetTarget = enemy;
            }
        }
        target = closetTarget;
    }
}
