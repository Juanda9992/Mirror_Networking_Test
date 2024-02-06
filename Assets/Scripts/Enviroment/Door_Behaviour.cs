using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mirror;

public class Door_Behaviour : NetworkBehaviour
{
    [SerializeField] private Transform doorTransform;
    [SerializeField] private float moveSpeed;
    private Vector3 initialPos;
    private Vector3 finalPos;
    [SyncVar]
    private bool opened = false;
    void Start()
    {
        initialPos = doorTransform.position; 
        finalPos = new Vector3(transform.position.x,transform.position.y -5,transform.position.z);       
    }

    public void UpdateBehaviour()
    {
        if(!opened)
        {
            OpenClienteRpc();
        }
        else
        {
            CloseClientRpc();
        }
        opened =!opened;
    }

    [ClientRpc]
    public void OpenClienteRpc()
    {
        doorTransform.DOMoveY(finalPos.y,moveSpeed);
    }

    [ClientRpc]
    public void CloseClientRpc()
    {
        doorTransform.DOMoveY(initialPos.y,moveSpeed);
    }
}
