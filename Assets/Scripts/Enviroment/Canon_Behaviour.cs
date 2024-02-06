using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Canon_Behaviour : NetworkBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float shootForce;

    [ContextMenu("Shoot"),ClientRpc]
    public void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab,transform.position,Quaternion.identity);

        ball.GetComponent<Rigidbody>().velocity = transform.forward * shootForce;
    }
}
