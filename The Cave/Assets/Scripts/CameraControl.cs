using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 30f;
    [SerializeField] float maxScroll = 5f;

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
                                         Mathf.Clamp(transform.position.z + deltaZ, -maxScroll, maxScroll));
    }

    private void HorisontalScroll()
    {
        float deltaX = Input.GetAxis("Horizontal") * scrollSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + deltaX, -maxScroll, maxScroll),
                                         transform.position.y,
                                         transform.position.z);
    }
}
