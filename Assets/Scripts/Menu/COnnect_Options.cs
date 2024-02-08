using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class COnnect_Options : MonoBehaviour
{
    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private Button hostButton;
    [SerializeField] private TMP_InputField roomId;
    [SerializeField] private Button joinButton;

    void Awake()
    {
        hostButton.onClick.AddListener(CreateHost);   
        roomId.onValueChanged.AddListener((string text)=>joinButton.interactable = text.Length > 0);
        joinButton.onClick.AddListener(JoinMatch);
    }

    private void CreateHost()
    {
        networkManager.StartHost();
        Debug.Log(networkManager.networkAddress);
    }

    private void JoinMatch()
    {
        networkManager.networkAddress = roomId.text;
        networkManager.StartClient();
    }
}
