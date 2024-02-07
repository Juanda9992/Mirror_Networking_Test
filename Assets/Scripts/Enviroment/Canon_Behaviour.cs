using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Canon_Behaviour : NetworkBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float shootForce;
    [SerializeField] private AudioSource thisSource;
    private GameObject currentBall;
    [ContextMenu("Shoot"),ClientRpc]
    public void Shoot()
    {
        thisSource.Play();
        if(!currentBall)
        {
            currentBall = Instantiate(ballPrefab,transform.position,Quaternion.identity);
        }
        currentBall.GetComponent<Rigidbody>().velocity = transform.forward * shootForce;
    }
}
