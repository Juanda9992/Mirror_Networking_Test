using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class Timer_Manager : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SyncVar]
    public int maxTime = 180;
    float currentSecond = 1;
    void Update()
    {
        currentSecond-= Time.deltaTime;
        if(currentSecond < 0)
        {
            currentSecond = 1;
            maxTime--;
            timerText.text = maxTime.ToString();
        }

    }
}
