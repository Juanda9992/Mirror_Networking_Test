using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Camera_Follow : NetworkBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    [SerializeField]private Transform followPos;

    void Start()
    {
        if(!isOwned)
        {
            Destroy(gameObject);
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
