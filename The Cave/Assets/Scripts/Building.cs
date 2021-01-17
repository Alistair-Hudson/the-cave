using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : PlayerAsset
{
    [SerializeField] float maxHealth = 100f;

    float health = 1f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (0 >= health)
        {
            Destroy(gameObject);
        }
    }

    public bool RepairDamage(float repairs)
    {
        health += repairs;
        if (health >= maxHealth)
        {
            health = maxHealth;
            return true;
        }
        return false;
    }
}
