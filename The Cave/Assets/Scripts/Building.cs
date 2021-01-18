using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : PlayerAsset
{
    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected int[] resourceCosts = new int[(int)ResourceType.NUM_RESOURCE_TYPES];

     protected float health = 1f;

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

    public int GetResourceCost(ResourceType resourceType)
    {
        return resourceCosts[(int)resourceType];
    }
}
