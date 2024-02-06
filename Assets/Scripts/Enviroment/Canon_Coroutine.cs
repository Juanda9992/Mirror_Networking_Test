using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Canon_Coroutine : NetworkBehaviour
{
    [SerializeField] private Canon_Behaviour[] canonCoroutine;

    [Server]
    private void StartCanonCoroutineServerRpc()
    {
        StartCoroutine("ShootCoroutine");
    }

    private IEnumerator ShootCoroutine()
    {
        while(true)
        {
            for(int i = 0; i< canonCoroutine.Length;i++)
            {
                canonCoroutine[i].Shoot();
                yield return new WaitForSeconds(2);
            }
        }
    }

    public override void OnStartServer()
    {
        StartCanonCoroutineServerRpc();
    }
}
