using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Bridge_Manager : NetworkBehaviour
{
    [SerializeField] private Bridge_Behaviour[] allBridges;

    private IEnumerator BridgeCoroutine()
    {
        while(true)
        {
            int brigesChanged = 0;
            for(int i = 0; i< allBridges.Length;i++)
            {
                if(Random.Range(0,2) == 1 && brigesChanged < 2)
                {
                    allBridges[i].DisableBridge();
                }
            }
            yield return new WaitForSeconds(2);
        }
    }
    public override void OnStartServer()
    {
        StartCoroutine(nameof(BridgeCoroutine));
    }
}
