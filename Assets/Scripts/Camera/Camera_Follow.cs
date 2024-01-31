using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    private Transform followPos;
    void Start()
    {
        followPos = GameObject.FindWithTag("Camera_Follow").transform;
    }

    void Update()
    {
        if(followPos == null)
        {
            followPos = GameObject.FindWithTag("Camera_Follow").transform;
        }
    }

    void LateUpdate()
    {
        if(followPos != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,followPos.rotation,rotSpeed  *Time.deltaTime);
            transform.position = Vector3.Slerp(transform.position,followPos.position,moveSpeed * Time.deltaTime);        
        }
    }
}
