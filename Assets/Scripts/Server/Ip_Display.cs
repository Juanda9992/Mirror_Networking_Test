using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class Ip_Display : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI ipText;
    [SerializeField] private NetworkManager networkManager;

    void Update()
    {
        if(isServer)
        {
            ipText.text = networkManager.networkAddress;
        }        
    }

}
