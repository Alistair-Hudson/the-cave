using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    
    void Update()
    {
        SnapToGrid();    
    }

    private void SnapToGrid()
    {
        Block block = GetComponent<Block>();
        transform.position = new Vector3(block.GetGridPos().x,
                                            block.GetGridPos().y,
                                            block.GetGridPos().z);
    }
}
