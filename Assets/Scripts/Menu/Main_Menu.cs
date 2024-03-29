using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private Button startButton;
    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private GameObject lobbyMenu;
    void Awake()
    {
        nameInput.onValueChanged.AddListener((string text)=>startButton.interactable = text.Length > 0);
        nameInput.onValueChanged.Invoke("");

        startButton.onClick.AddListener(Connect);    
    }

    private void Connect()
    {
        Player_Name.playerName = nameInput.text;
        gameObject.SetActive(false);
        lobbyMenu.SetActive(true);
    }
}
