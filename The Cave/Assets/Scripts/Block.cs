using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int availbleResources = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetGridPos()
    {
        return new Vector3(Mathf.RoundToInt(transform.position.x / transform.lossyScale.x) * transform.lossyScale.x,
                           Mathf.RoundToInt(transform.position.y / transform.lossyScale.y) * transform.lossyScale.y,
                           Mathf.RoundToInt(transform.position.z / transform.lossyScale.z) * transform.lossyScale.z);
    }

    public void MineBlock()
    {
        --availbleResources;
        if (0 >= availbleResources)
        {
            Destroy(gameObject);
        }
    }

    public int GetAvailbleResources()
    {
        return availbleResources;
    }
}
