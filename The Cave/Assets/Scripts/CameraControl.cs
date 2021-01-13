using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorisontalScroll();
        VerticalScroll();
        
    }

    private void VerticalScroll()
    {
        float deltaZ = Input.GetAxis("Vertical") * scrollSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         transform.position.z + deltaZ);
    }

    private void HorisontalScroll()
    {
        float deltaX = Input.GetAxis("Horizontal") * scrollSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + deltaX,
                                         transform.position.y,
                                         transform.position.z);
    }
}
