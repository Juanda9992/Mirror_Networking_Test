using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Crown : NetworkBehaviour
{   
    public static Action OnCrownGrabbed;
    public void GetCrownCmd()
    {
        Debug.Log("Crown grabbed");
        GetCrownClientRpc();
    }

    [ClientRpc]
    private void GetCrownClientRpc()
    {
        OnCrownGrabbed?.Invoke();
    } 

}
