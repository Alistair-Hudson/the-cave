using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] MonsterAI[] monsterPrefads;
    [SerializeField] Transform spawnPoint;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            MonsterAI newMonster = Instantiate(monsterPrefads[0], spawnPoint);
            newMonster.transform.parent = transform;
        }
    }
}
